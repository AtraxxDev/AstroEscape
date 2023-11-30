using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCanva3 : MonoBehaviour
{
    public GameObject panelUI;
    public TMP_Text resultadoText;
    public int numeroLimiteDesactivarObjeto = 100; // Establece el n�mero l�mite en el Inspector
    public string Trofeo12;

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
                    Debug.LogWarning("El texto no contiene un n�mero v�lido: " + texto.text);
                }
            }

            Debug.Log("La suma total de los n�meros en los textos es: " + sumaTotal);

            resultadoText.text = "Your score: " + sumaTotal;

            // Verificar si la suma total es mayor al n�mero l�mite
            if (sumaTotal > numeroLimiteDesactivarObjeto)
            {
                // Almacenar la informaci�n en PlayerPrefs
                PlayerPrefs.SetInt("ResultadoTextValor", sumaTotal);
                PlayerPrefs.SetInt("DesactivarObjeto", 1);
            }
        }
       
    }

    public void CambiarAEscenaOtra()
    {
        Time.timeScale = 1f;

        // Cambia el n�mero 1 con el �ndice de la escena que deseas cargar
        int indiceDeLaOtraEscena = 0;
        SceneManager.LoadScene(indiceDeLaOtraEscena);
    }
}
