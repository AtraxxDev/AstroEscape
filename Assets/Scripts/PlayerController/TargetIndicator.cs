using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform target;
    public float hideDistance;

    void Update()
    {
        if (target == null)
            return;

        // Direcci�n hacia el objetivo
        Vector3 direction = target.position - transform.position;

        // Rotaci�n hacia el objetivo
        transform.up = direction.normalized;

        // Activar o desactivar seg�n la distancia
        bool isClose = direction.magnitude < hideDistance;
        setChildrenActive(!isClose);
    }

    void setChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }

}
