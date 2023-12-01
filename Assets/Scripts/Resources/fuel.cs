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
    public List<TMP_Text> PuntuacionTexts;
    public GameObject panelFinal;
    public GameObject botnCmbioNivel;

    void Start()
    {
        fuelAmount = Mathf.Clamp(fuelAmount, 0f, maxFuel);
        ActualizarPuntuacion();
    }

    void Update()
    {
        if (fuelAmount <= 0)
        {
           
            panelFinal.gameObject.SetActive(true);
            botnCmbioNivel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        {
            
        }
        if (Input.GetKey(KeyCode.W) && fuelAmount > 0)
        {
            fuelAmount -= Time.deltaTime;
            fuelBar.fillAmount = fuelAmount / maxFuel;
            Puntuacionfuel();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            fuelAmount -= Time.deltaTime * 50;
            fuelAmount = Mathf.Clamp(fuelAmount, 0f, maxFuel);
            fuelBar.fillAmount = fuelAmount / maxFuel;
            Puntuacionfuel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gasolina"))
        {
            fuelAmount += refill;
            fuelAmount = Mathf.Clamp(fuelAmount, 0f, maxFuel);
            ActualizarPuntuacion();
        }
    }

    private void Puntuacionfuel()
    {
        if (fuelAmount <= 300 && fuelAmount > 150)
        {
            ActualizarPuntuacion(1000);
        }
        else if (fuelAmount <= 150 && fuelAmount > 50)
        {
            ActualizarPuntuacion(500);
        }
        else if (fuelAmount <= 50)
        {
            ActualizarPuntuacion(250);
        }
        else
        {
            ActualizarPuntuacion(0);
        }
    }

    private void ActualizarPuntuacion(int puntuacion = 0)
    {
        foreach (TMP_Text text in PuntuacionTexts)
        {
            text.text =  puntuacion.ToString();
        }
    }
}
