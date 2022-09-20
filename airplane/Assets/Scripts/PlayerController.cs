using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float speed = 100f; //touch speed;
    //public float speed = 2f; // computer input speed;
    private Vector2 startPos, endPos;
    private Vector2 dir;

    private float horizon;
    private float vertic;
    //public Text text;

    public GameObject deadEffect;

    private int hp;
    private int maxhp = 100;

    public bool Damagable;
    private SpriteRenderer render;

    public void GetHp(int value)
    {
        hp += value;
        if (hp > maxhp)
            hp = maxhp;

        GameManager.manager.hpBar.value = hp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy" && Damagable)
        {
            Die();
        }
    }

    public void Damage(int value)
    {
        if (hp <= 0)
            return;

        if(Damagable)
        {
            hp -= value;
            StartCoroutine(AttackEffect());
            GameManager.manager.hpBar.value = hp;
            //Debug.Log("player hp : " + hp);
            if (hp <= 0) // player dead
            {
                Die();
            }
        }
    }

    private void Die()
    {
        GameManager.manager.playerDead = true;
        Instantiate(deadEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        hp = maxhp;
        Damagable = true;
        render = GetComponent<SpriteRenderer>();
        render.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        /*horizon = Input.GetAxisRaw("Horizontal");
        vertic = Input.GetAxisRaw("Vertical");

        if (horizon != 0 || vertic != 0)
        {
            rigid.velocity = new Vector2(horizon * speed, vertic * speed);
        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }*/

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                endPos = touch.position;

                float x = endPos.x - startPos.x;
                float y = endPos.y - startPos.y;
                
                dir = new Vector2(x, y).normalized;

                rigid.velocity = dir*speed;
                //text.text = rigid.velocity.ToString();

            }

        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }
    }

    private IEnumerator AttackEffect()
    {
        render.color = Color.grey;
        yield return new WaitForSeconds(.1f);
        render.color = Color.white;
    }
}
