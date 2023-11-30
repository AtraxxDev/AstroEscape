using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationalSpeed = 0.5f;
    public float maxAngularVelocity = 5f;  // Nueva variable para limitar la velocidad angular
    public float thrustForce = 0.5f;
    public float turboMultiplier = 2.0f;
    public float brakeForce = 0.5f;
    private Rigidbody2D rb;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float thrustInput = Input.GetAxis("Vertical");

        float rotation = -rotationInput * rotationalSpeed;
        rb.rotation += rotation;

        // Limitar la velocidad angular
        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxAngularVelocity, maxAngularVelocity);

        Vector2 thrustDirection = transform.up;
        float thrust = thrustForce * thrustInput;

        if (thrustInput < 0)
        {
            rb.AddForce(-thrustDirection * brakeForce);
        }
        else
        {
            rb.AddForce(thrustDirection * thrust);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(thrustDirection * thrustForce * turboMultiplier, ForceMode2D.Impulse);
        }
    }
}
