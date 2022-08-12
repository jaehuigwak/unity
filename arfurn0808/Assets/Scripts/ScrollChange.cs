using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollChange : MonoBehaviour
{
    public GameObject[] scrollObject;
    public void activeScroll(int num)
    {
        for(int i=0;i<scrollObject.Length;i++)
        {
            if (i == num)
                continue;
            scrollObject[i].SetActive(false);   
        }
        scrollObject[num].SetActive(true);
    }    
}
