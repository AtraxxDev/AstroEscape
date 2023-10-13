using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float rotationalSpeed = 5.0f;
    public float thrustForce = 10.0f;
    public float turboMultiplier = 2.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener la entrada del jugador
        float rotationInput = Input.GetAxis("Horizontal");
        float thrustInput = Input.GetAxis("Vertical");

        // Rotación
        float rotation = -rotationInput * rotationalSpeed; // Negativo para invertir la dirección
        rb.rotation += rotation;

        // Impulso
        Vector2 thrustDirection = transform.up;
        float thrust = thrustForce * thrustInput;
        rb.velocity = thrustDirection * thrust;

        // Turbo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Si se presiona la barra espaciadora, aumenta el impulso
            rb.velocity *= turboMultiplier;
        }
    }
}
