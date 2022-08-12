using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{   
    public void Exit()
    {
        Application.Quit();
    }

    public void SceneChange(int num)
    {
        SceneManager.LoadScene(num);
    }


}
