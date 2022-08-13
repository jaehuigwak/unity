using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float height;

    private void Awake()
    {
        height = transform.localScale.y;
        Debug.Log("height : " + height);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>= 2* height)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(0, -height * 4);
        transform.position = (Vector2)transform.position + offset;
    }
}
