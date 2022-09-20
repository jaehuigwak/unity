using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    public GameObject boss;
    private GameObject instance;

    public int maxNum = 1; // 스폰된 적과 아이템의 최대 개수

    private ScrollObject scroll;
    public EnemySpawner[] enemys;

    //private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //instance = new GameObject();
        instance = Instantiate(boss, poolPos, Quaternion.identity);
        scroll = instance.GetComponent<ScrollObject>();

    }

    // Update is called once per frame
    void Update()
    {
       if(GameManager.manager.spawnCnt>=maxNum)
        {
            for(int i=0;i<enemys.Length;i++)
            {
                enemys[i].enabled = false;
            }

            StartCoroutine(BossCreate());
/*            if (instance.transform.position.y>=2.5f)
            {
                instance.transform.Translate(Vector3.down * Time.deltaTime * speed);
            }*/
        }
    }

    private IEnumerator BossCreate()
    {
        GameManager.manager.bossCreate = true;
        yield return new WaitForSeconds(3f);
        instance.transform.position = new Vector2(0, 2.5f);
        instance.SetActive(true);
    }
}
