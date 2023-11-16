using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class fuel : MonoBehaviour
{
    public TMP_Text timerText;
    public Image fuelBar;
    public float fuelAmount;
    public float maxFuel = 300f;
    public float refill = 50f;
    private int PuntuacionText;


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
        Puntuacionfuel();
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
    public void Puntuacionfuel()
    {
        if (fuelAmount <= 250)
        {
            PuntuacionText = 1000;  
            timerText.text = PuntuacionText.ToString();      
        }
        if (fuelAmount <= 150)
        {
            PuntuacionText = 500;
            timerText.text = PuntuacionText.ToString();        
        }
        if (fuelAmount <= 50)
        {
            PuntuacionText = 250;
            timerText.text = PuntuacionText.ToString();
        }
     
    }
}
