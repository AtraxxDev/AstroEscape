using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount;
    public float maxHealth = 8f;

    private void Start()
    {
        healthAmount = maxHealth;
    }
    public void TakeDamage()
    {
        healthAmount -= 1f;
        healthBar.fillAmount = healthAmount / 8f;

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

}
