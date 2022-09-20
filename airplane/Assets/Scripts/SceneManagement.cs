using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public void SceneChange(int num)
    {
       /* if(Time.timeScale==0)
        {
            Debug.Log("time scale =0 ");
            Time.timeScale = 1;
            Debug.Log("time scale =1 ");
        }*/
        SceneManager.LoadScene(num);
    }

    public void onExit()
    {
        Application.Quit();
    }

}
