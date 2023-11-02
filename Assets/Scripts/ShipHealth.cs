using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public Image healthBar;
    public float healthAmount;
    public float maxHealth = 8f;
    private int healthScore;
    public string SceneName;
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
            healthScore = 1000;
            healthText.text = healthScore.ToString();
            Debug.Log("Mi puntuacion es" + healthScore);
        }
        if (healthAmount <= 5)
        {
            healthScore = 500;
            healthText.text = healthScore.ToString();
            Debug.Log("Mi puntuacion es" + healthScore);
        }
        if (healthAmount <= 2)
        {
            healthScore = 250;
            healthText.text = healthScore.ToString();
            Debug.Log("Mi puntuacion es" + healthScore);
        }
        if (healthAmount == 0)
        {
            healthScore = 0;
            SceneManager.LoadScene(SceneName);
        }
    }

}
