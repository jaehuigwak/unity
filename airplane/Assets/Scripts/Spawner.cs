using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objs;
    protected int idx = 0;

    public float xMin = -2f;
    public float xMax = 2f;
    protected float yPos = 5.5f;

    protected Vector2 poolPos = new Vector2(0, 10);
    public static List<float> pos = new List<float>();


    void Awake()
    {
        idx = 0;
    }

    public float getRandom(float a,float b)
    {
        float result = Random.Range(a, b);

        while(pos.Contains(result))
        {
            result = Random.Range(a, b);
        }
        pos.Add(result);
        return result;
    }

    public int getCnt()
    {
        return pos.Count;
    }

    public void initList()
    {
        pos.Clear();
    }
}
