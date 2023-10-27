using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timmer : MonoBehaviour
{
    public float maxTime = 60.0f; // Tiempo máximo del temporizador en segundos.
    private float currentTime;

    private bool isRunning = false;

    public TMP_Text timerText; // Agrega una referencia al elemento de interfaz de usuario.

    private void Start()
    {
        currentTime = 0; // Comienza desde cero.
        StartTimer();

        // Asegúrate de que timerText esté asignado en el Inspector.
        if (timerText == null)
        {
            Debug.LogError("El objeto TimerText no está asignado en el Inspector.");
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime; // Suma tiempo en lugar de restarlo.
            UpdateTimerText(); // Llama a la función para actualizar el texto del temporizador.  
        }    
    }
    public void StartTimer()
    {
        isRunning = true;
    }
    public void StopTimer()
    {
        isRunning = false;
    }
    public void ResetTimer()
    {
        currentTime = 0; // Reinicia el temporizador a cero.
        isRunning = false;
        UpdateTimerText(); // Asegúrate de actualizar el texto al reiniciar el temporizador.
    }
    public void GuardarTime() // Aqui se guardara el tiempo 
    {
        Debug.Log(currentTime); //Se guarda el tiempo
    }
    public  void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Tiempo: " + currentTime.ToString("F2"); // Muestra el tiempo con dos decimales.
           
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Debug.Log("detecte collision");
        {
            Debug.Log("empece rutinas ");
            StopTimer();
            GuardarTime();
            Destroy(gameObject);
        }
    }

}



