using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    public GameObject[] itemprefab;


    private float timeBetSpawn;
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        objs = new GameObject[itemprefab.Length];

        for (int i = 0; i < itemprefab.Length; i++)
        {
            objs[i] = Instantiate(itemprefab[i], poolPos, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.manager.playerDead)
            return;

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = 15f;

            float xPos = getRandom(xMin, xMax);
            idx = Random.Range(0, objs.Length);
            //Debug.Log("item random idx : " + idx);

            objs[idx].SetActive(true);
            objs[idx].transform.position = new Vector2(xPos, yPos);
        }
    }
}
