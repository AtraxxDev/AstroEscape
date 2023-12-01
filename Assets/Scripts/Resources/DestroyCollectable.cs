using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectable : MonoBehaviour
{
    public GameObject collectable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collectable);
        }
    }
}
