using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
            transform.position = player.position + new Vector3(0, 2, -3);
    }
}
