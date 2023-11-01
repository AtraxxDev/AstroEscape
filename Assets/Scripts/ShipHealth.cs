using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public Image healthBar;
    public float healthAmount;
    public float maxHealth = 8f;
    private int health;
    private void Start()
    {
        healthAmount = maxHealth;
        
    }
    public void TakeDamage()
    {
        healthAmount -= 1f;
        healthBar.fillAmount = healthAmount / 8f;

    }
    private void Update()
    {
        PuntuacionHealth();
    }

    public void HealAmounth(float healingAmounth)
    {
        healthAmount += healingAmounth;
        healthAmount = Mathf.Clamp(healthAmount,0, 100);
        if (healthAmount > maxHealth)
        {
            healthAmount = maxHealth;
        }

        healthBar.fillAmount = healthAmount / 8f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }

    private void PuntuacionHealth()
    {
        if (healthAmount <= 7)
        {
            health = 1000;
            healthText.text = health.ToString();
            Debug.Log("Mi puntuacion es" + health);
        }
        if (healthAmount <= 5)
        {
            health = 500;
            healthText.text = health.ToString();
            Debug.Log("Mi puntuacion es" + health);
        }
        if (healthAmount <= 2)
        {
            health = 250;
            healthText.text = health.ToString();
            Debug.Log("Mi puntuacion es" + health);
        }
       /* if (healthAmount >= 7)
        {
            health = 1000;
            healthText.text = health.ToString();
            Debug.Log("Mi puntuacion es" + health);
        }
        if (healthAmount >= 6)
        {
            health = 500;
            healthText.text = health.ToString();
            Debug.Log("Mi puntuacion es" + health);
        }
        if (healthAmount >= 3)
        {
            health = 250;
            healthText.text = health.ToString();
            Debug.Log("Mi puntuacion es" + health);
        }*/
    }

}
