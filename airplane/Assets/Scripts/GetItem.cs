using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    enum Item{HP=6,WEAPON,SHIELD};
    PlayerController player;

    List<BulletSpawner> spawners=new List<BulletSpawner>();

    public GameObject shieldItem;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Item")
        {
            //audio.PlayOneShot(itemclip);
            switch(collision.gameObject.layer)
            {
                case (int)Item.HP:
                    player.GetHp(50);
                    collision.gameObject.SetActive(false);
                    break;
                case (int)Item.WEAPON:
                    StartCoroutine(GetWeapon());
                    collision.gameObject.SetActive(false);
                    break;
                case (int)Item.SHIELD:
                    StartCoroutine(GetShield());
                    collision.gameObject.SetActive(false);
                    break;
            }
        }
    }

    private IEnumerator GetShield()
    {
        shieldItem.SetActive(true);
        player.Damagable = false;

        yield return new WaitForSeconds(5.0f);

        shieldItem.SetActive(false);
        player.Damagable = true;
    }

    private IEnumerator GetWeapon() // 수정 필요...
    {
        for(int i=0;i<spawners.Count;i++)
        {
            if (i == 0)
            {
                spawners[i].enabled = false; 
                continue;
            }
            spawners[i].enabled = true;
        }

        yield return new WaitForSeconds(7.0f);

        for (int i = 0; i < spawners.Count; i++)
        {
            if (i == 0)
            {
                spawners[i].enabled = true;
                continue;
            }
            spawners[i].enabled = false; // 인스펙터 창에서는 반영되지만 어째서인지 bullet이 계속 생성됨... -> StopCoroutine 사용법을 제대로 숙지하지 않아서..
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();

        BulletSpawner[] tmp = GetComponents<BulletSpawner>();
        foreach(BulletSpawner spawn in tmp)
        {
            spawners.Add(spawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
