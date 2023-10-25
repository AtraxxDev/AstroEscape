using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuel : MonoBehaviour
{
    public Image fuelBar;
    public float fuelAmount;
    public float maxFuel = 300f;
    public float refill = 50f;
    
    void Start()
    {
        fuelAmount = maxFuel;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            fuelAmount -= Time.deltaTime;
            fuelBar.fillAmount = fuelAmount -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            fuelAmount -= Time.deltaTime * 2;
            fuelBar.fillAmount = fuelAmount -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gasolina"))
        {
            fuelAmount += refill;
            if (fuelAmount > maxFuel)
            {
                fuelAmount = maxFuel;
            }
        }
    }
}
