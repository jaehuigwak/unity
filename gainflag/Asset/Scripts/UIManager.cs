using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //[SerializeField] GameObject createName;

    public void Popup(GameObject obj)
    {
        obj.SetActive(true);
    }
}
