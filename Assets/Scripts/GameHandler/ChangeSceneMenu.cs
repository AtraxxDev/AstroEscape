using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMenu : MonoBehaviour
{
    public AudioSource buttonPlay;
    public AudioSource musicBG;
    public void StartGame()
    {
        StartCoroutine(StartG());
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuP");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator StartG()
    {
        musicBG.Stop();

        if (buttonPlay != null) 
        {
            buttonPlay.Play();
        }
        
        yield return new WaitForSeconds(buttonPlay.clip.length);
        SceneManager.LoadScene("LevelSelect");
    }

}
