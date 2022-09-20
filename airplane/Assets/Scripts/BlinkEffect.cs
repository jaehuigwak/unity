using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkEffect : MonoBehaviour
{
    TextMeshProUGUI text;

    private IEnumerator Blink()
    {
        if (text != null)
        {
            Time.timeScale = 1;
            while (true)
            {
                text.enabled = true;
                yield return new WaitForSeconds(.5f);
                text.enabled = false;
                yield return new WaitForSeconds(.5f);
            }
        }
    }

    void OnEnable()
    {
        StartCoroutine(Blink());
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start");
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Blink());
    }

}
