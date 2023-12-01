using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoAsteroides : MonoBehaviour
{
    public GameObject des;
    public float tiempoDes;
    public float vel;
    void Update()
    {
        
        transform.position += Vector3.right * vel * Time.deltaTime;

        Destroy(des, tiempoDes);
        
    }
}
