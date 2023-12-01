using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipHealth : MonoBehaviour
{
    public List<TMP_Text> healthTexts;
    public Image healthBar;
    public float healthAmount;
    public float maxHealth = 10f;
    public GameObject finalPanel;
    public GameObject changeSceneButton;
    private void Start()
    {
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
        UpdateScore();
    }
    private void Update()
    {
        if(healthAmount <= 0)
        {
            Time.timeScale = 0f;
            finalPanel.gameObject.SetActive(true);
            changeSceneButton.gameObject.SetActive(true);
        }
    }
    public void TakeDamage()
    {
        healthAmount -= 1f;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
        healthBar.fillAmount = healthAmount / maxHealth;
        UpdateScore();
    }

    public void HealAmount(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
        healthBar.fillAmount = healthAmount / maxHealth;
        UpdateScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }

    private void UpdateScore()
    {
        int puntuation = 0;

        if (healthAmount <= 3)
        {
            puntuation = 250;
        }
        else if (healthAmount <= 5)
        {
            puntuation = 500;
        }
        else if (healthAmount <= 10)
        {
            puntuation  = 1000;
        }

        SetScore(puntuation);
    }

    private void SetScore(int puntuation)
    {
        foreach (TMP_Text text in healthTexts)
        {
            text.text = puntuation.ToString();
        }
    }
}
