using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager uInstance;
    [SerializeField] Slider playerHp;
    [SerializeField] Slider enemyHp;

    void Awake()
    {
        if(uInstance == null)
        {
            uInstance = this;
        }
        else
        {
            if(uInstance!=this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {

    }

    public void Popup(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void setPlayerHp(float value)
    {
        playerHp.value = value;
    }

    public void setEnemyHp(float value)
    {
        enemyHp.value = value;
    }
}
