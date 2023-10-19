using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount;
    public float maxHealth = 8f;

    public void TakeDamage()
    {
        healthAmount -= -1f;
        healthBar.fillAmount = healthAmount / 100f;

    }

    public void HealAmounth(float healingAmounth)
    {
        healthAmount += healingAmounth;
        healthAmount = Mathf.Clamp(healthAmount,0, 100);
        if (healthAmount > maxHealth)
        {
            healthAmount = maxHealth;
        }

        healthBar.fillAmount = healthAmount / 100f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            TakeDamage();
        }
    }

}
