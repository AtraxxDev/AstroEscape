using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRAVITON : MonoBehaviour
{
    Rigidbody2D rB;
    public PlanetGravity pG;

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
                if (pG != null && !pG.attractees.Contains(this.GetComponent<Rigidbody2D>()))
                {
                    pG.attractees.Add(rB);
                }
            }
            else if (value == false)
            {
                if (pG != null)
                {
                    pG.attractees.Remove(rB);
                }
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
                if (pG != null && !pG.attractors.Contains(this.GetComponent<Rigidbody2D>()))
                {
                    pG.attractors.Add(rB);
                }
            }
            else if (value == false)
            {
                if (pG != null)
                {
                    pG.attractors.Remove(rB);
                }
            }
            isAttractive = value;
        }
    }

    [SerializeField] bool isAttractive;
    [SerializeField] bool isAttractee;

    [SerializeField] Vector3 initialVel;
    [SerializeField] bool applyInitialVelocityOnStart;
    //[SerializeField] float G = 1;

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
        if (pG != null)
        {
            pG.attractors.Remove(rB);
            pG.attractees.Remove(rB);
        }
    }

    void ApplyVelocity(Vector3 velocity)
    {
        rB.AddForce(initialVel, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Planet"))
        {
            if (other.TryGetComponent<PlanetGravity>(out PlanetGravity planetG))
            {
                pG = planetG;
                isAttractee = true;
            }
            if (pG != null && !pG.attractees.Contains(this.GetComponent<Rigidbody2D>()))
            {
                pG.attractees.Add(rB);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Planet"))
        {
            isAttractee = false;
            if (pG != null)
            {
                pG.attractees.Remove(rB);
            }
            pG = null;
        }
    }
}
