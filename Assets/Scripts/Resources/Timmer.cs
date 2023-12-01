using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timmer : MonoBehaviour
{
    public GameObject ArrowGO;
    public float maxTime = 60.0f;
    private float currentTime;
    private bool isRunning = false;
    public List<TMP_Text> timerTexts; // Cambiado a una lista para permitir múltiples objetos TMP_Text.
    public GameObject colliderPortal;

    private void Start()
    {
        currentTime = 0;
        StartTimer();


        // Asegúrate de que timerTexts esté asignado en el Inspector.
        if (timerTexts == null || timerTexts.Count == 0)
        {
           
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            UpdateTimerText();
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
        currentTime = 0;
        isRunning = false;
        UpdateTimerText();
    }

    public void LogTime()
    {
        Debug.Log(currentTime);
    }

    public void UpdateTimerText()
    {
        foreach (TMP_Text text in timerTexts)
        {
            text.text = "Time: " + currentTime.ToString("F2");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopTimer();
            LogTime();
            colliderPortal.SetActive(true);
            ArrowGO.SetActive(true);
            Destroy(gameObject);
        }
    }
}
