using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Gun gun;
    private PlayerInput input;
    private Animator anim;

    private void Awake()
    {
        gun = GetComponent<Gun>();
        input = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input!=null)
        {
            if(input.fire)
            {
                gun.Fire();
            }
        }
    }
}
