using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoAsteroides : MonoBehaviour
{
    public float vel;
    void Update()
    {
        transform.position += Vector3.right * vel * Time.deltaTime;
    }
}
