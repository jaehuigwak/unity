using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public GameObject enemyprefab;

    public int enemyCnt = 2;

    // Start is called before the first frame update
    void Start()
    {
        objs = new GameObject[enemyCnt];

        for (int i = 0; i < enemyCnt; i++)
        {
            objs[i] = Instantiate(enemyprefab, poolPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.manager.playerDead)
            return;

        Debug.Log("enemy idx : " + idx);
        if (objs[idx].activeSelf == false)
        {
            float xPos = getRandom(xMin, xMax);

            objs[idx].SetActive(false);
            objs[idx].transform.position = new Vector2(xPos, yPos);
            objs[idx++].SetActive(true);

            if (idx >= enemyCnt)
            {
                idx = 0;
            }
        }
    }
}
