using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    public Image timer_linear_image;
    float time_remaining;
    public float max_time = 120f;

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
    }
}
