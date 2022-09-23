using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput input;
    private Rigidbody rigid;
    private Animator anim;
    float speed = 8;

    private void Awake()
    {
        input= GetComponent<PlayerInput>();
        rigid= GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(input!=null)
        {
            Vector3 dir = Vector3.zero;

            if(input.hmove!=0 || input.vmove!=0)
            {
                dir = input.hmove * Vector3.right + input.vmove * Vector3.forward;
                transform.rotation=Quaternion.LookRotation(dir);
                rigid.MovePosition(rigid.position + dir * speed * Time.deltaTime);
            }

            anim.SetFloat("move", Mathf.Clamp(dir.magnitude,-1.0f,1.0f));
            //anim.SetFloat("move", Mathf.Clamp(input.vmove+input.hmove, -1.0f, 1.0f));

            //Debug.Log(Mathf.Clamp(dir.magnitude, -1.0f, 1.0f));
            //Debug.Log(Mathf.Clamp(input.vmove + input.hmove, -1.0f, 1.0f));

        }
    }

    private void Slide() //모션 블러 효과 구현하기 - postProcessing 활용할 것.
    {

    }
}
