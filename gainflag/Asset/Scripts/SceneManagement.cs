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
}
