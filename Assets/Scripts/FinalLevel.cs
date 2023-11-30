using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    public GameObject panel;
    public GameObject botn;

    private bool tiempoDetenido = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !tiempoDetenido)
        {
            Time.timeScale = 0f;
            panel.gameObject.SetActive(true);
            botn.gameObject.SetActive(true);

            // Aquí puedes restablecer el tiempo antes de cargar la nueva escena
            // Pero no restablecerlo aquí, ya que queremos mantenerlo detenido hasta que se cargue la nueva escena
            // Time.timeScale = 1f;

            tiempoDetenido = true;
        }
    }

    // Función para cargar la nueva escena
    public void CargarNuevaEscena()
    {
        // Restablecer el tiempo antes de cargar la nueva escena
        Time.timeScale = 1f;

        // Puedes cambiar "LevelSelect" al nombre de la escena que deseas cargar
        SceneManager.LoadScene("LevelSelect");
    }
}
