using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oxygen : MonoBehaviour
{
    public List<TMP_Text> OxygenTexts;
    public Image timer_linear_image;
    public float time_remaining;
    private float max_time = 120f;
    public float oxygenRecovery = 15f;

    private void Start()
    {
        time_remaining = Mathf.Clamp(time_remaining, 0f, max_time);
        timer_linear_image.fillAmount = time_remaining / max_time;
    }

    private void Update()
    {
        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            timer_linear_image.fillAmount = time_remaining / max_time;
        }

        PuntuacionOxygen();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("oxigeno"))
        {
            time_remaining += oxygenRecovery;
            time_remaining = Mathf.Clamp(time_remaining, 0f, max_time);
        }
    }

    public void PuntuacionOxygen()
    {
        int oxygen = 0;

        if (time_remaining <= 40)
        {
            oxygen = 250;
        }
        else if (time_remaining <= 80)
        {
            oxygen = 500;
        }
        else
        {
            oxygen = 1000;
        }

        SetPuntuacion(oxygen);
    }

    private void SetPuntuacion(int puntuacion)
    {
        foreach (TMP_Text text in OxygenTexts)
        {
            text.text = puntuacion.ToString();
        }
    }
}
