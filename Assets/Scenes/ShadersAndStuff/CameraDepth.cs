using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraDepth : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        //cam = GetComponent<Camera>();
    }

    void Update()
    {
        cam.depthTextureMode = DepthTextureMode.Depth;
        
    }

}
