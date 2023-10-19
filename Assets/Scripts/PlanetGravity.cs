using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField] float g = 1f;
    static float G;

    public  List<Rigidbody2D> attractors = new List<Rigidbody2D>();
    public  List<Rigidbody2D> attractees = new List<Rigidbody2D>();
    public static bool isSimulatingLive = true;

    private void FixedUpdate()
    {
        G = g;
        if (isSimulatingLive)
            SimulateGravities();
    }

    public void SimulateGravities()
    {
        foreach(Rigidbody2D attractor in attractors)
        {
            foreach(Rigidbody2D attractee in attractees)
            {
                if (attractor != attractee)
                    AddGravityForce(attractor, attractee);
            }
        }
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
