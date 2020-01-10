using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour
{
   
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
