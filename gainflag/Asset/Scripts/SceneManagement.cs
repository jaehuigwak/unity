using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void SceneLoad(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //init gamemanager values
        GameManager.gInstance.enabled = false;
        GameManager.gInstance.enabled = true;
    }
}
