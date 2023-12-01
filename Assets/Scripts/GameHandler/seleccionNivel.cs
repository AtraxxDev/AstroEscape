using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class seleccionNivel : MonoBehaviour
{
    public string nombreDeLaEscena;
    public GameObject objeto;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(cambioEs);
    }

    public void cambioEs()
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("entro");
            objeto.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("salio");
            objeto.SetActive(false);
        }
    }
}
