using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2 : MonoBehaviour
{
    public  void ChangeEscene()
    {
        
        int indiceDeLaOtraEscena = 0;

        SceneManager.LoadScene(indiceDeLaOtraEscena);
    }

}
