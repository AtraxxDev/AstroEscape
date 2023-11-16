using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    public GameObject panel;

    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.gameObject.CompareTag("Player"))        
        {          
            Time.timeScale = 0f;    
            panel.gameObject.SetActive(true);
        }
    }
}
