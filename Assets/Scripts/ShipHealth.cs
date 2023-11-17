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
    //public GameObject panel;
    private void Start()
    {
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
        ActualizarPuntuacion();
    }
    private void Update()
    {
        if(healthAmount == 0)
        {
            Time.timeScale = 0f;
          //  panel.gameObject.SetActive(true);
        }
    }
    public void TakeDamage()
    {
        healthAmount -= 1f;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
        healthBar.fillAmount = healthAmount / maxHealth;
        ActualizarPuntuacion();
    }

    public void HealAmount(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);
        healthBar.fillAmount = healthAmount / maxHealth;
        ActualizarPuntuacion();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }

    private void ActualizarPuntuacion()
    {
        int puntuacion = 0;

        if (healthAmount <= 3)
        {
            puntuacion = 250;
        }
        else if (healthAmount <= 5)
        {
            puntuacion = 500;
        }
        else if (healthAmount <= 10)
        {
            puntuacion = 1000;
        }

        SetPuntuacion(puntuacion);
    }

    private void SetPuntuacion(int puntuacion)
    {
        foreach (TMP_Text text in healthTexts)
        {
            text.text = puntuacion.ToString();
        }
    }
}
