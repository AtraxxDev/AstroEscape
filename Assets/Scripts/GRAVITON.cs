using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRAVITON : MonoBehaviour
{
    Rigidbody2D rB;

    public bool IsAttractee
    {
        get
        {
            return isAttractee;
        }
        set
        {
            if (value == true)
            {
                if (!PlanetGravity.attractees.Contains(this.GetComponent<Rigidbody2D>()))
                {
                    PlanetGravity.attractees.Add(rB);
                }
            }
            else if (value == false)
            {
                PlanetGravity.attractees.Remove(rB);
            }
            isAttractee = value;
        }
    }

    public bool IsAttractive
    {
        get
        {
            return isAttractive;
        }
        set
        {
            if (value == true)
            {
                if (!PlanetGravity.attractors.Contains(this.GetComponent<Rigidbody2D>()))
                    PlanetGravity.attractors.Add(rB);
            }
            else if (value == false)
            {
                PlanetGravity.attractors.Remove(rB);
            }
            isAttractive = value;
        }
    }

    [SerializeField] bool isAttractive;
    [SerializeField] bool isAttractee;

    [SerializeField] Vector3 initialVel;
    [SerializeField] bool applyInitialVelocityOnStart;
    [SerializeField] float G = 1;

    private void Awake()
    {
        rB = this.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        IsAttractive = isAttractive;
        IsAttractee = isAttractee;
    }

    void Start()
    {

        if (applyInitialVelocityOnStart)
        {
            ApplyVelocity(initialVel);
        }
    }

    private void OnDisable()
    {
        PlanetGravity.attractors.Remove(rB);
        PlanetGravity.attractees.Remove(rB);
    }

    void ApplyVelocity(Vector3 velocity)
    {
        rB.AddForce(initialVel, ForceMode2D.Impulse);
    }
   
}
