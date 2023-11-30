using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCanva : MonoBehaviour
{
    public GameObject panelUI; 
    public TMP_Text resultadoText; 

    void Start()
    {
        if (panelUI != null)
        {
            panelUI.SetActive(false);
        }
    }

    void Update()
    {
        if (panelUI != null && panelUI.activeSelf)
        {
            SumarNumerosEnTextos();
        }
    }

    void SumarNumerosEnTextos()
    {
        if (resultadoText != null)
        {
            TMP_Text[] textosEnPanel = panelUI.GetComponentsInChildren<TMP_Text>();

            int sumaTotal = 0;

            foreach (TMP_Text texto in textosEnPanel)
            {
                int numeroEnTexto;
                if (int.TryParse(texto.text, out numeroEnTexto))
                {
                    sumaTotal += numeroEnTexto;
                }
                else
                {
                    Debug.LogWarning("El texto no contiene un número válido: " + texto.text);
                }
            }

            Debug.Log("La suma total de los números en los textos es: " + sumaTotal);

            resultadoText.text = "Your score: " + sumaTotal;
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto TMP_Text para mostrar el resultado en el Inspector.");
        }
    }
    public void CambiarAEscenaOtra()
    {
        SceneManager.LoadScene("TestLevel");
    }
}
