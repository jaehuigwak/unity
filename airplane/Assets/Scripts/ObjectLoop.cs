using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoop : MonoBehaviour
{
    public float height = 5f;
    public float xMin = -2f;
    public float xMax = 2f;

    //private Spawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        //spawn = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<=-height)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        float xPos = GameManager.manager.spawner.getRandom(xMin, xMax);
        transform.position = new Vector2(xPos,height);
    }
}
