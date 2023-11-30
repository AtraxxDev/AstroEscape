using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seleccionNiveles : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform[] puntos;
    private int indicePuntoActual = 0;
    private bool enMovimientoAutomatico = false;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
        }
        else
        {
            Vector3 direccion = puntos[indicePuntoActual].position - transform.position;
            direccion.Normalize();

            transform.Translate(direccion * velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, puntos[indicePuntoActual].position) < 0.1f)
            {
                enMovimientoAutomatico = false;
            }
        }
    }
}
