using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLoop : MonoBehaviour
{
    float speed = 30.0f;
    // Update is called once per frame
    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void Update()
    {
        transform.Rotate(0, speed*Time.deltaTime, 0);
    }
}
