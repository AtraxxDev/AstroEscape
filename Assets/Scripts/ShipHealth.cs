using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{

    public Image healthBar;
    public float healthAmount = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        healthAmount -= -1f;
        healthBar.fillAmount = healthAmount / 100f;

    }

    public void HealAmounth(float healingAmounth)
    {
        healthAmount += healingAmounth;
        healthAmount = Mathf.Clamp(healthAmount,0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
