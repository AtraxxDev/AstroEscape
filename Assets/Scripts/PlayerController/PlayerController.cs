using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationalSpeed = 0.5f;
    public float maxangularVelocity = 5f;
    public float thrustForce = 0.5f;
    public float turboMultiplier = 2.0f;
    public float brakeForce = 0.5f;
    public float maxSpeed = 5f;  // Nueva variable para limitar la velocidad máxima
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float thrustInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            thrustInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            thrustInput = -1f;
        }

        float rotation = -rotationInput * rotationalSpeed;
        rb.rotation += rotation;

        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxangularVelocity, maxangularVelocity);

        Vector2 thrustDirection = transform.up;
        float thrust = thrustForce * thrustInput;

        if (thrustInput < 0)
        {
            rb.velocity -= rb.velocity.normalized * brakeForce * Time.deltaTime;
        }
        else if (thrustInput > 0 && rb.velocity.magnitude < maxSpeed) // Clamp de velocidad máxima
        {
            rb.AddForce(thrustDirection * thrust);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(thrustDirection * thrustForce * turboMultiplier, ForceMode2D.Impulse);
        }
    }
}
