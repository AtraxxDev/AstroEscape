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

    private bool isInTrigger = false;

    void Start()
    {
        // No hay cambios en el método Start
    }

    void Update()
    {
        if (isInTrigger)
        {
            // Encuentra todos los objetos en la escena con la etiqueta especificada
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(targetTag);

            // Si hay al menos un objeto con la etiqueta especificada
            if (objectsWithTag.Length > 0)
            {
                // Inicializa el objeto más cercano y su distancia al primer objeto de la lista
                Transform nearestObject = objectsWithTag[0].transform;
                float nearestDistance = Vector3.Distance(nearestObject.position, transform.position);

                // Itera sobre todos los objetos para encontrar el más cercano
                foreach (GameObject obj in objectsWithTag)
                {
                    float distance = Vector3.Distance(obj.transform.position, transform.position);
                    if (distance < nearestDistance)
                    {
                        nearestObject = obj.transform;
                        nearestDistance = distance;
                    }
                }

                // Limita el zoom al rango establecido
                float zoom = Mathf.Clamp(nearestDistance, maxZoom, minZoom);

                // Imprime mensajes de depuración si se alcanzan los límites de zoom
                if (nearestDistance < minZoom)
                {
                    Debug.Log("maxZoom");
                }
                else if (nearestDistance > maxZoom)
                {
                    Debug.Log("minZoom");
                }

                // Aplica un zoom suavizado a la cámara
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * zoomSpeed);
            }
        }
    }

    // Se llama cuando otro collider entra en el trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isInTrigger = true;
        }
    }

    // Se llama cuando otro collider sale del trigger.
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isInTrigger = false;
        }
    }
}
