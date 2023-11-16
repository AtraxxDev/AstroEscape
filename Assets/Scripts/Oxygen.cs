using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oxygen : MonoBehaviour
{

    public TMP_Text OxygenText;
    public Image timer_linear_image;
    public float time_remaining;
    public float max_time = 120f;
    public float oxygenRecovery = 15f;
    private int oxygen;
    ShipHealth sh;

    void Start()
    {
        time_remaining = max_time;
        timer_linear_image.fillAmount = time_remaining / max_time;
    }

    void Update()
    {
        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            timer_linear_image.fillAmount = time_remaining / max_time;
        }
        //if (time_remaining > 0 && sh.healthAmount <= 4f)
        //{
        //time_remaining -= Time.deltaTime * 2;
        //timer_linear_image.fillAmount = time_remaining / max_time;
        //}
       PuntuacionOxygen();
        //PuntuacionOxygen2();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("oxigeno"))
        {
            time_remaining += oxygenRecovery;
            if (time_remaining > max_time)
            {
                time_remaining = max_time;
            }
        }
    }
 

    public void PuntuacionOxygen() 
    {     
        if (time_remaining <= 100)// Sie s menor que 100 su puntuacion sera igual a 1000 y asi todos los de abajo 
        {
            oxygen = 1000;
            OxygenText.text = oxygen.ToString();
        }
        if (time_remaining <= 80)
        {
            oxygen = 500;
            OxygenText.text = oxygen.ToString();
        }
        if (time_remaining <= 40)
        {
            oxygen = 250;
            OxygenText.text = oxygen.ToString();
        }
        if (time_remaining >= 40)
        {
            oxygen = 250;
            OxygenText.text = oxygen.ToString();
        }
        if (time_remaining >= 80)
        {
            oxygen = 500;
            OxygenText.text = oxygen.ToString();
        }
        if (time_remaining >= 100)
        {
            oxygen = 1000;
            OxygenText.text = oxygen.ToString();
        }
    }
}
