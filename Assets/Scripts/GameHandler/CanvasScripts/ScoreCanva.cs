using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCanva : MonoBehaviour
{
    public GameObject panelUI;
    public TMP_Text textResult;
    public int limitNum = 100; // Establece el n�mero l�mite en el Inspector
    public string trophe12;

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
            TotalTextNumbers();
        }
    }

    void TotalTextNumbers()
    {
        if (textResult != null)
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

            textResult.text = "Your score: " + sumaTotal;

            // Verificar si la suma total es mayor al n�mero l�mite
            if (sumaTotal > limitNum)
            {
                // Almacenar la informaci�n en PlayerPrefs
                PlayerPrefs.SetInt("ResultadoTextValor", sumaTotal);
                PlayerPrefs.SetInt("DesactivarObjeto", 1);
            }
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto TMP_Text para mostrar el resultado en el Inspector.");
        }
    }

    public void ChangeScenes()
    {
        Time.timeScale = 1f;

        // Cambia el n�mero 1 con el �ndice de la escena que deseas cargar
        int indiceDeLaOtraEscena = 1;
        SceneManager.LoadScene(indiceDeLaOtraEscena);
    }
}