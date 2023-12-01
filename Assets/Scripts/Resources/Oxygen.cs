using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oxygen : MonoBehaviour
{
    public List<TMP_Text> oxygenTexts;
    public Image timerLinearImage;
    public float timeRemaining;
    private float maxTime = 120f;
    public float oxygenRecovery = 15f;
    public GameObject finalPanel;
    public GameObject changeSceneButton;

    private void Start()
    {
        timeRemaining = Mathf.Clamp(timeRemaining, 0f, maxTime);
        timerLinearImage.fillAmount = timeRemaining / maxTime;
    }

    private void Update()
    {
        if(timeRemaining <= 0)
        {
            finalPanel.gameObject.SetActive(true);
            changeSceneButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerLinearImage.fillAmount = timeRemaining / maxTime;
        }

        OxygenScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("oxigeno"))
        {
            timeRemaining += oxygenRecovery;
            timeRemaining = Mathf.Clamp(timeRemaining, 0f, maxTime);
        }
    }

    public void OxygenScore()
    {
        int oxygen = 0;

        if (timeRemaining <= 40)
        {
            oxygen = 250;
        }
        else if (timeRemaining <= 80)
        {
            oxygen = 500;
        }
        else
        {
            oxygen = 1000;
        }

        SetPuntuation(oxygen);
    }

    private void SetPuntuation(int puntuacion)
    {
        foreach (TMP_Text text in oxygenTexts)
        {
            text.text = puntuacion.ToString();
        }
    }
}
