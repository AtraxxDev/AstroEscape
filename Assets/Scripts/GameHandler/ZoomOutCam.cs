
using UnityEngine;

public class ZoomOutCam : MonoBehaviour
{
    public string targetTag = "";
    public float zoomSpeed = 2.0f;
    public float minZoom = 10.0f;
    public float maxZoom = 50.0f;
    public float zoomInDelay = 1.0f; // Ajusta el retraso al salir del trigger
    public Camera cam;

    private bool isInTrigger = false;
    private float timeSinceExitTrigger = 0f;
    private void Start()
    {
       
    }

    void Update()
    {
        if (isInTrigger)
        {
            // Realiza el zoom out si el jugador está dentro del collider
            float zoom = Mathf.Clamp(maxZoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * zoomSpeed);

            // Restablece el temporizador de salida del trigger
            timeSinceExitTrigger = 0f;
        }
        else
        {
            // Incrementa el temporizador de salida del trigger
            timeSinceExitTrigger += Time.deltaTime;

            // Si ha pasado el tiempo de retraso, realiza el zoom in
            if (timeSinceExitTrigger >= zoomInDelay)
            {
                float zoom = Mathf.Clamp(minZoom, minZoom, maxZoom);
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * zoomSpeed);
            }
        }
    }

    // Se llama cuando otro collider entra en el trigger.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isInTrigger = true;
        }
    }

    // Se llama cuando otro collider sale del trigger.
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isInTrigger = false;
        }
    }
}

