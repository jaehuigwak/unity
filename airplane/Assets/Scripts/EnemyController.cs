using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int hp;
    public int maxHP;

    public GameObject deadEffect;
    public int score = 10;
    private GameObject effect;
    private SpriteRenderer render;

    public void Damage(int value)
    {
        if (hp <= 0)
            return;

        hp -= value;
        StartCoroutine(AttackEffect());
        Debug.Log("Enemy hp : " + hp);

        if(hp<=0)
        {
            Die();
            GameManager.manager.AddScore(score);
        }
    }

    private void OnEnable()
    {
        hp = maxHP;
        if(render!=null)
        {
            render.color = Color.white;
        }
    }

    private void Die()
    {
        if(gameObject.layer==9) //enemy == boss
        {
            GameManager.manager.bossDie = true;
        }
        effect=Instantiate(deadEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
        Destroy(effect, 3.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        hp=maxHP;
        render = GetComponent<SpriteRenderer>();
        render.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator AttackEffect()
    {
        render.color = Color.grey;
        yield return new WaitForSeconds(.1f);
        render.color = Color.white;
    }
}
