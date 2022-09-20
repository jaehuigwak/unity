using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;

    public float spawnRate; //cycle of spawn
    public int spawnNum = 3; //num of bullet for one shot
    public int startnum = -1; //start angle : 0 = forward, -1 : -30 angle

    private Coroutine routine;

    void OnEnable()
    {
        if (spawnNum > 1)
        {
            routine=StartCoroutine(spawnBullet(spawnNum));
        }
        else
        {
            routine=StartCoroutine(spawnBullet());
        }
    }

    void OnDisable()
    {
        StopCoroutine(routine);
    }


    IEnumerator spawnBullet()
    {
        while (true)
        {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    IEnumerator spawnBullet(int num)
    {
        while (true)
        {
            for(int i=startnum;i<num+startnum;i++)
            {
                Quaternion rotate = Quaternion.Euler(shootPoint.rotation.x, shootPoint.rotation.y, 30 * i);
                Instantiate(bulletPrefab, shootPoint.position, rotate);
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
