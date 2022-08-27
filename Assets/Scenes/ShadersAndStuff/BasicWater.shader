Shader "Unlit/BasicWater"
{

    // similar to variables in C++ / C#, reference assets and etc
    Properties
    {
        _FoamTex ("Foam Texture", 2D) = "white" {}
        _WaveNoiseTex("Wave Noise Texture", 2D) = "white" {}

        _ShallowDepthCol("Shallow Depth Color", Color) = (0, 0, 0, 0)
        _SeafloorDepthCol("Seafloor Color", Color) = (0, 0, 0, 0)

        _MaxDepth("Max Depth", Float) = 0.5

        _WaterTransparency("Water Transparency", Float) = 0.8

        _FoamCutoff("Foam Cutoff Point", Float) = 0.7
        _FoamSpeed("Foam Move Speed", Vector) = (0.06, 0.06, 0)
        _FoamSize("Foam Texture Sampling Size", Vector) = (0.01, 0.01, 0)

        _WaveSpeed("Wave Move Speed", Float) = 60
        _WaveIntensity("Wave Intensity", Float) = 0.15

    }

    // code determining how the shader should function goes here.
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent"} // { "RenderType"="Opaque" }

        Blend SrcAlpha OneMinusSrcAlpha // set the blending mode of pixels to one minus the alpha

        // where we do all our render calculations
        Pass
        {
            CGPROGRAM // define the program type

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // data container for data coming from the cpu, defines what data we're using
            struct appdata
            {
                float4 vertex : POSITION; // the ": POSITION" part indicates this float4 represents pos data.
                //float4 waveVertex;
                float2 uv : TEXCOORD0; // refers to the texture at register 0.
                float2 uv2 : TEXCOORD1;
                //float2 depthScreenPos : TEXCOORD1; // represents point being sampled on the depth texture.
                // uv represents a coordinate for where a pixel on a texture should be on a mesh.
            };

            // define the data being edited in the vert function and passed to the frag function.
            // in vert, we take data in from appdata, and edit v2f with them, then return v2f.
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float uv2 : TEXCOORD1;
                float4 vertex : SV_POSITION;
                //float4 waveVertex;

                float4 vertexScreenPos : TEXCOORD2; // value for the depth factor of water (calculated with depth texture)
            };


            sampler2D _FoamTex; // the sampler samples the pixels from the texture given, using the uv coordinates given.
            float4 _FoamTex_ST; // xy controls tiling amount, zw controls offset amount

            sampler2D _WaveNoiseTex;
            float4 _WaveNoiseTex_ST;

            float4 _ShallowDepthCol;
            float4 _SeafloorDepthCol;

            float _MaxDepth;
            float _WaterTransparency;

            float _FoamCutoff;
            float3 _FoamSpeed;
            float3 _FoamSize;

            float _WaveSpeed;
            float _WaveIntensity;

            sampler2D _CameraDepthTexture; // passing directly from unity camera, no need for property def


            // take in the vertex mesh data of our object from appdata, set up every vertex and pass to the next func
            v2f vert (appdata vertInput)
            {
                v2f vertOutput;

                vertOutput.vertex = UnityObjectToClipPos(vertInput.vertex); // this func transforms the given vertex from local object space to world space (camera's clip space) by matrix multiplication.
                //vertOutput.waveVertex = UnityObjectToClipPos(vertInput.waveVertex);

                vertOutput.uv = TRANSFORM_TEX(vertInput.uv, _FoamTex); // scale and offset the given texture, by taking the ST data of that texture and editing

                float waveNoiseSample = tex2Dlod(_WaveNoiseTex, float4(vertInput.uv2, 0, 0)); // sample a point on the noise texture to get a "random" float value
                float waveNoise = sin(_Time * _WaveSpeed * waveNoiseSample); // multiply our value by time to change it over time, and use sine wave to create a back and forth in the value
                vertOutput.vertex.xy += waveNoise * _WaveIntensity; // offset the given vertex's position by adding the "randomised" value to it
                //vertOutput.vertex.y += waveNoise;//TRANSFORM_TEX(vertInput.uv, _WaveNoiseTex);

                vertOutput.vertexScreenPos = ComputeScreenPos(vertOutput.vertex); // compute the depth value of the given vertex being calculated. gets the position of the point in the camera space

                return vertOutput;
            }

            // take the output of the previous func, and colour each pixel in the mesh triangles. runs once for every pixel
            float4 frag (v2f fragInput) : SV_Target
            {
                
                float4 depthSample = tex2Dproj(_CameraDepthTexture, fragInput.vertexScreenPos); // sample the camera's depth texture using the given vertex depth to translate to world space. tex2Dproj is tex2D, except xy / w
                float4 linearDepth = LinearEyeDepth(depthSample); // get the linear version of our depth sample  
                //float4 getDepth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, fragInput.depthScreenPos);
                //UNITY_OUTPUT_DEPTH(fragInput.depthScreenPos);

                float2 currentFoamUV = ((fragInput.uv.x * _FoamSize.x) + _Time.x * _FoamSpeed.x, (fragInput.uv.y * _FoamSize.y) + _Time.y * _FoamSpeed.y);  // shift the current texture sampling point each timestep
                float4 foamSample = tex2D(_FoamTex, currentFoamUV); // sample the texture, use the sampler to get the color value of the texture at the given uv pixel coordinate
                
                //float4 depthDiff = linearDepth.w - fragInput.depthScreenPos.w; // (linearDepth.x, linearDepth.y, linearDepth.z, linearDepth.w - fragInput.depthScreenPos.w);
                float maximumDepth = clamp((linearDepth.w - fragInput.vertexScreenPos.w) * _MaxDepth, 0, 1);  // get the difference between the current depth and the surface (depthScreenPos.w gives surface depth), then divide by the max depth render
                float4 waterCol = lerp(_ShallowDepthCol, _SeafloorDepthCol, maximumDepth); // lerp between the two colours of shallow and deep water, depending on the depth value

                //float4 foamCol = float4(tex2D(_FoamTex, float2(waterCol, 0.5)).rgb, 1.0);
                float maxFoamAtDepth = maximumDepth * _FoamCutoff; // multiply with depth to have sampled foam texture concentrate at shallow depth
                float4 finalFoam = foamSample > maxFoamAtDepth; // give us the foam from the text only if the value of the sampled point is higher than the given cutoff value

                //float waveMovement = tex2D(_WaveNoiseTex, fragInput.uv2.xy, 0, 0);
                fixed4 transparency = (1, 1, 1, _WaterTransparency); // add some transparency to the water
                return fixed4((waterCol.rgb + finalFoam.rgb), transparency.a);
            }

            ENDCG // end program
        }
    }
}
