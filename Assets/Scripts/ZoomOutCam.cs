using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZoomOutCam : MonoBehaviour
{
        public Transform target;
        public float zoomSpeed = 2.0f;
        public float minZoom = 10.0f;
        public float maxZoom = 50.0f;

        public Camera cam;

        void Start()
        {
           // cam = GetComponent<Camera>();
        }

        void Update()
        {
            float distance = Vector3.Distance( target.position,transform.position);
            float zoom = Mathf.Clamp(distance, maxZoom, minZoom);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * zoomSpeed);
        
        }
}


