using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public  void ChangeEsceneAnother()
    {
        
        int theOtherEscene = 0;

        SceneManager.LoadScene(theOtherEscene);
    }

}
