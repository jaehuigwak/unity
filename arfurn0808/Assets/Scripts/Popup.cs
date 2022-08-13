using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject popup;

    public void MenuUp()
    {
        popup.SetActive(true);
    }

    public void MenuDown()
    {
        popup.SetActive(false);
    }
}
