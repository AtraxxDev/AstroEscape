using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddGravityForce(Rigidbody2D attractor, Rigidbody2D target)
    {
        float massProduct = attractor.mass * target.mass * G;

        Vector3 difference = attractor.position - target.position;
        float distance = difference.magnitude;

        //Esto es F=G*((m1*m2)/r2)
        float unScaledforceMagnitude = massProduct / distance * distance;
        float forceMagnitude = G * unScaledforceMagnitude;

        Vector3 forceDirection = difference.normalized;

        Vector3 forceVector = forceDirection * forceMagnitude;
        target.AddForce(forceVector);
    }
}
