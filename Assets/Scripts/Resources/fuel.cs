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
    public List<TMP_Text> puntuationText;
    public GameObject finalpanel;
    public GameObject changeSceneButton;

    void Start()
    {
        fuelAmount = Mathf.Clamp(fuelAmount, 0f, maxFuel);
        UpdateScore();
    }

    void Update()
    {
        if (fuelAmount <= 0)
        {
           
            finalpanel.gameObject.SetActive(true);
            changeSceneButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        {
            
        }
        if (Input.GetKey(KeyCode.W) && fuelAmount > 0)
        {
            fuelAmount -= Time.deltaTime;
            fuelBar.fillAmount = fuelAmount / maxFuel;
            PuntuationFuel();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            fuelAmount -= Time.deltaTime * 50;
            fuelAmount = Mathf.Clamp(fuelAmount, 0f, maxFuel);
            fuelBar.fillAmount = fuelAmount / maxFuel;
            PuntuationFuel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gasolina"))
        {
            fuelAmount += refill;
            fuelAmount = Mathf.Clamp(fuelAmount, 0f, maxFuel);
            UpdateScore();
        }
    }

    private void PuntuationFuel()
    {
        if (fuelAmount <= 300 && fuelAmount > 150)
        {
            UpdateScore(1000);
        }
        else if (fuelAmount <= 150 && fuelAmount > 50)
        {
            UpdateScore(500);
        }
        else if (fuelAmount <= 50)
        {
            UpdateScore(250);
        }
        else
        {
            UpdateScore(0);
        }
    }

    private void UpdateScore(int puntuacion = 0)
    {
        foreach (TMP_Text text in puntuationText)
        {
            text.text =  puntuacion.ToString();
        }
    }
}
