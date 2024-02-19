using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Point
{
    public int ID;
    public Transform transform;
}

public class LevelSelector : MonoBehaviour
{
    public float speed = 5f;
    public Point[] points;
    private int currentIndex = 0;
    private bool automaticMovement = false;
    
    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (points.Length == 0)
        {
            Debug.LogWarning("No hay puntos especificados.");
            return;
        }

        if (!automaticMovement)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (currentIndex < points.Length - 1)
                {
                    currentIndex++;
                    automaticMovement = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.A) && currentIndex > 0)
            {
               currentIndex--;
                automaticMovement = true;
            }

            // Verificar si está en el punto y presiona la tecla "E"
            if (Input.GetKeyDown(KeyCode.E) && OnPoint())
            {
                ChangeScene();
            }
        }
        else
        {
            Vector3 direccion = points[currentIndex].transform.position - transform.position;
            direccion.Normalize();

            transform.Translate(direccion * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, points[currentIndex].transform.position) < 0.1f)
            {
                automaticMovement = false;
            }
        }
    }

    bool OnPoint()
    {
        float distanciaAlPunto = Vector3.Distance(transform.position, points[currentIndex].transform.position);
        return distanciaAlPunto < 0.1f;
    }

    void ChangeScene()
    {
        // Utilizar switch para manejar diferentes casos según el ID
        switch (points[currentIndex].ID)
        {
            case 1:
                SceneManager.LoadScene("TrueLevel1");
                break;

            case 2:
                SceneManager.LoadScene("Level 2");
                break;

            case 3:
                SceneManager.LoadScene("Level 3");
                break;

            case 4:
                SceneManager.LoadScene("Level 4");
                break;

            case 5:
                SceneManager.LoadScene("Level 5");
                break;

            default:
                Debug.Log("Spawn");
                Debug.LogWarning("ID no manejado: " + points[currentIndex].ID);
                break;
        }
    }
}
