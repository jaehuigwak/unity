using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int shotDamage = 20;
    public float speed = 5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.Damage(shotDamage);
            }
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up* speed * Time.deltaTime);
    }
}
