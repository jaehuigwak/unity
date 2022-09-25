using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uInstance;
    [SerializeField] Slider playerHp;
    [SerializeField] Slider enemyHp;
    [SerializeField] Image shotButton;
    [SerializeField] Slider validTimer;
    [SerializeField] TextMeshProUGUI remainAmmo;
    [SerializeField] TextMeshProUGUI remainHpItem;

    private float gaugeTimer = .0005f;

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
    public void setEnemyMaxHp(float value)
    {
        enemyHp.maxValue = value;
    }

    public void ShotButtonInvalidEffect()
    {
        shotButton.color = Color.grey;
    }

    public void ShotButtonValidEffect()
    {
        shotButton.color = Color.white;
    }

    public IEnumerator ValidShotTimer(float reloadTime)
    {
        validTimer.value = 0;

        while(validTimer.value < reloadTime)
        {
            validTimer.value += gaugeTimer;
            Debug.Log("Loading value : "+validTimer.value);
            yield return new WaitForSeconds(gaugeTimer);
        }
    }

    public void setRemainAmmoText(int value)
    {
        remainAmmo.text = value.ToString();
    }

    public void setRemainHpItemText(int remain)
    {
        remainHpItem.text = remain.ToString();
    }

}
