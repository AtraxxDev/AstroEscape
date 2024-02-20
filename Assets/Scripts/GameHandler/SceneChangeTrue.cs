using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrue : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonPlay;
    [SerializeField] private AudioSource _musicBG;
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
        _musicBG.Stop();

        if (_buttonPlay != null)
        {
            _buttonPlay.Play();
        }

        yield return new WaitForSeconds(_buttonPlay.clip.length);
        SceneManager.LoadScene("LevelSelect");
    }

}
