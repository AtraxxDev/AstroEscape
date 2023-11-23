using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seleccionNiveles : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform[] puntos;
    private int indicePuntoActual = 0;
    private bool enMovimientoAutomatico = false;

    void Update()
    {
        if (puntos.Length == 0)
        {
            Debug.LogWarning("No hay puntos especificados.");
            return;
        }

        // Si no está en movimiento automático, verifica la entrada del jugador
        if (!enMovimientoAutomatico)
        {
            // Avanzar al siguiente punto al presionar 'D'
            if (Input.GetKeyDown(KeyCode.D))
            {
                indicePuntoActual = (indicePuntoActual + 1) % puntos.Length;
                enMovimientoAutomatico = true;
            }

            // Retroceder al punto anterior al presionar 'A'
            if (Input.GetKeyDown(KeyCode.A) && indicePuntoActual > 0)
            {
                indicePuntoActual--;
                enMovimientoAutomatico = true;
            }
        }
        else
        {
            // Si está en movimiento automático, mueve la nave hacia el punto actual
            Vector3 direccion = puntos[indicePuntoActual].position - transform.position;
            direccion.Normalize();

            transform.Translate(direccion * velocidad * Time.deltaTime);

            // Verifica si la nave ha llegado al punto actual
            if (Vector3.Distance(transform.position, puntos[indicePuntoActual].position) < 0.1f)
            {
                // Detén el movimiento automático y espera la entrada del jugador
                enMovimientoAutomatico = false;
            }
        }
    }
}
