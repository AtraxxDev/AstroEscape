using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Desaparecer : MonoBehaviour
{
    public int valorLimite = 500;
    public GameObject objetoADesactivar;

    void Start()
    {
        
        int resultadoTextValor = PlayerPrefs.GetInt("ResultadoTextValor", 0);

        
        if (resultadoTextValor > valorLimite)
        {
            if (objetoADesactivar != null)
            {
                objetoADesactivar.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No se ha asignado el objeto a desactivar en el Inspector.");
            }
        }

        
        PlayerPrefs.DeleteKey("UpdateText");
    }
}