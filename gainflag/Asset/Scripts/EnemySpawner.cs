using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 TODO
 complete createEnemy script
 */
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;

    private float maxDamage = 50f;
    private float minDamage = 5f;

    private float maxSpeed = 3.0f;
    private float minSpeed = .5f;

    private List<Enemy> enemies = new List<Enemy>();
    public int Maplevel { get; private set; }

    void Awake()
    {
        Maplevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnLevel()
    {
        Maplevel++;

        int spawnCnt = Mathf.RoundToInt(Maplevel * 1.5f);

        for(int i=0;i<spawnCnt;i++)
        {
            CreateEnemy(Maplevel);
        }
    }

    private void CreateEnemy(float level)
    {
        
    }


}
