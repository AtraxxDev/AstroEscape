using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Dissapear : MonoBehaviour
{
    public int limit = 500;
    public GameObject deactivateObj;

    void Start()
    {
        // Obtener el valor guardado en PlayerPrefs
        int resultadoTextValor = PlayerPrefs.GetInt("ResultadoTextValor", 0);

        // Verificar si el valor es mayor a 500 y desactivar el objeto
        if (resultadoTextValor > limit)
        {
            if (deactivateObj != null)
            {
                deactivateObj.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No se ha asignado el objeto a desactivar en el Inspector.");
            }
        }

        // Limpiar PlayerPrefs después de usarlo
        PlayerPrefs.DeleteKey("ResultadoTextValor");
    }
}