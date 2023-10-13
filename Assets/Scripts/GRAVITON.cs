using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRAVITON : MonoBehaviour
{
    Rigidbody2D rB;
    public bool IsAttractive;
    public bool IsAttractee;
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
        GravityHandler.attractors.Remove(rB);
        GravityHandler.attractees.Remove(rB);
    }

    void ApplyVelocity(Vector3 velocity)
    {
        rB.AddForce(initialVel, ForceMode2D.Impulse);
    }
}
