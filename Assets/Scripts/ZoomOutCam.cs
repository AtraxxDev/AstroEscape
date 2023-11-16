using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZoomOutCam : MonoBehaviour
{
    public string targetTag = ""; 
    public float zoomSpeed = 2.0f;
    public float minZoom = 10.0f;
    public float maxZoom = 50.0f;

    public Camera cam;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

        if (objectsWithTag.Length > 0)
        {
            Transform nearestObject = objectsWithTag[0].transform;
            float nearestDistance = Vector3.Distance(nearestObject.position, transform.position);

            foreach (GameObject obj in objectsWithTag)
            {
                float distance = Vector3.Distance(obj.transform.position, transform.position);
                if (distance < nearestDistance)
                {
                    nearestObject = obj.transform;
                    nearestDistance = distance;
                }
            }

            float zoom = Mathf.Clamp(nearestDistance,maxZoom, minZoom);

            if (nearestDistance < minZoom)
            {
                
                Debug.Log("maxZoom");
            }
            else if (nearestDistance > maxZoom)
            {
                
                Debug.Log("minZoom");
            }

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * zoomSpeed);
        }
    }
}


