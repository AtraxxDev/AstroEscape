using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrue : MonoBehaviour
{
    public  void ChangeEscene()
    {
        
        int indiceDeLaOtraEscena = 0;

        SceneManager.LoadScene(indiceDeLaOtraEscena);
    }

}
