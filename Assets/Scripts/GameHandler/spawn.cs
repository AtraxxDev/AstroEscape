using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject objetoPrefab; 
    public float minY = 1.0f;
    public float maxY = 5.0f; 
    public float tiempoDeSpawn;
    public float maxTime;
    public float minTime;

    private float tiempoTranscurrido = 0.0f;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoDeSpawn)
        {
            SpawnObject();
            tiempoTranscurrido = 0.0f;
            tiempoDeSpawn = Random.Range(minTime, maxTime);

        }
    }

    void SpawnObject()
    {
        
        float randomY = Random.Range(minY, maxY);

        
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        Instantiate(objetoPrefab, spawnPosition, Quaternion.identity);
    }



}
