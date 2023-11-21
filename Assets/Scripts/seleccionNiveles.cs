using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seleccionNiveles : MonoBehaviour
{

    public float velocidad = 5f;
    public Transform[] puntos; 
    private int indicePuntoActual = 0; 

    void Update()
    {
        
        if (puntos.Length == 0)
        {
            Debug.LogWarning("No hay puntos especificados.");
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            
            Vector3 direccion = puntos[indicePuntoActual].position - transform.position;
            direccion.Normalize();

            
            transform.Translate(direccion * velocidad * Time.deltaTime);

            
            if (Vector3.Distance(transform.position, puntos[indicePuntoActual].position) < 0.1f)
            {
                
                indicePuntoActual = (indicePuntoActual + 1) % puntos.Length;
            }
        }
        /*else if (Input.GetKey(KeyCode.A))
        {
            
            Vector3 direccion = transform.position - puntos[indicePuntoActual].position;
            direccion.Normalize();

           
            transform.Translate(direccion * velocidad * Time.deltaTime);

            
            if (Vector3.Distance(transform.position, puntos[indicePuntoActual].position) > 0.1f)
            {
                
                indicePuntoActual = (puntos.Length + indicePuntoActual - 1) % puntos.Length;
            }
        }*/
    }
}
