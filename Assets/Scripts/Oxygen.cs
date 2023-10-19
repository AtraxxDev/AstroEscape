using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public Image timer_linear_image;
    float time_remaining;
    public float max_time = 120f;
    public float oxygenRecovery = 15f;
    ShipHealth sh;

    void Start()
    {
        time_remaining = max_time;
    }

    void Update()
    {
        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            timer_linear_image.fillAmount = time_remaining / max_time;
        }
        if (time_remaining > 0 && sh.healthAmount <= 4f)
        {
            time_remaining -= Time.deltaTime * 2;
            timer_linear_image.fillAmount = time_remaining / max_time;
        }
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
}
