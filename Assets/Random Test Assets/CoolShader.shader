Shader "Unlit/CoolShader"
{
    Properties
    {
        _FirstTex ("Texture", 2D) = "white" {}
        _SecondTex ("Texture", 2D) = "white" {}
        _WaveColor ("Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha 

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            //#pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 uv2 : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 uv2 : TEXCOORD1;

                //UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            // these appear in the inspector
            sampler2D _FirstTex;
            float4 _FirstTex_ST;

            sampler2D _SecondTex;
            float4 _SecondTex_ST;

            float4 _WaveColor;// = fixed4(1, 0, 1, 1);


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _FirstTex);
                o.uv2 = TRANSFORM_TEX(v.uv2, _SecondTex);

                //UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            // runs once per pixel, sets each pixel
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 cleffa = tex2D(_FirstTex, i.uv);
                fixed4 waves = tex2D(_SecondTex, i.uv2);// float2(i.uv2.x, i.uv2.y));// * fixed4(0, 0, 1, 1);

                
                fixed4 final = fixed4(cleffa.rgb * (waves.rgb + _WaveColor.rgb), waves.a * cleffa.a);
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                return final;
            }
            ENDCG
        }
    }
}
