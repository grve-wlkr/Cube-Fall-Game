using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraScaler : MonoBehaviour
{
    public float targetWorldWidth = 5f; // game area width

    private void Awake()
    {
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = targetWorldWidth / (2f * cam.aspect);
        
    }






} // class
