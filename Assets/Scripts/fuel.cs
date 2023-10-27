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
    public int PuntuacionText;

    void Start()
    {
        fuelAmount = maxFuel;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            fuelAmount -= Time.deltaTime;
            fuelBar.fillAmount = fuelAmount / maxFuel;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            fuelAmount -= Time.deltaTime * 50;
            fuelBar.fillAmount = fuelAmount / maxFuel;
        }
        Puntuacion();
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
    private void Puntuacion()
    {
        if (fuelAmount >= 250)
        {
            PuntuacionText = 1000;
            Debug.Log("Mi puntuacion es" + PuntuacionText);
        }
    }
}
