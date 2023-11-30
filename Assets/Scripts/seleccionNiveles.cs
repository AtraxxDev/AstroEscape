using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Punto
{
    public int ID;
    public Transform transform;
}

public class seleccionNiveles : MonoBehaviour
{
    public float velocidad = 5f;
    public Punto[] puntos;
    private int indicePuntoActual = 0;
    private bool enMovimientoAutomatico = false;
    void Start()
    {
       
    }

    void Update()
    {
        if (puntos.Length == 0)
        {
            Debug.LogWarning("No hay puntos especificados.");
            return;
        }

        if (!enMovimientoAutomatico)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (indicePuntoActual < puntos.Length - 1)
                {
                    indicePuntoActual++;
                    enMovimientoAutomatico = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.A) && indicePuntoActual > 0)
            {
                indicePuntoActual--;
                enMovimientoAutomatico = true;
            }

            // Verificar si está en el punto y presiona la tecla "E"
            if (Input.GetKeyDown(KeyCode.E) && EstaEnElPunto())
            {
                CambiarEscena();
            }
        }
        else
        {
            Vector3 direccion = puntos[indicePuntoActual].transform.position - transform.position;
            direccion.Normalize();

            transform.Translate(direccion * velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, puntos[indicePuntoActual].transform.position) < 0.1f)
            {
                enMovimientoAutomatico = false;
            }
        }
    }

    bool EstaEnElPunto()
    {
        float distanciaAlPunto = Vector3.Distance(transform.position, puntos[indicePuntoActual].transform.position);
        return distanciaAlPunto < 0.1f;
    }

    void CambiarEscena()
    {
        // Utilizar switch para manejar diferentes casos según el ID
        switch (puntos[indicePuntoActual].ID)
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
                Debug.LogWarning("ID no manejado: " + puntos[indicePuntoActual].ID);
                break;
        }
    }
}
