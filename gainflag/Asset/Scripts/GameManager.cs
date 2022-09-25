using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gInstance;
    public bool isGameOver { get; private set; }
    private int score = 0;

    void Awake()
    {
        if(gInstance == null)
        {
            gInstance = this;
        }
        else
        {
            if(gInstance!=this)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnEnable()
    {
        isGameOver = false;
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerHealth>().onDeath += EndGame;
    }

    public void AddScore(int value)
    {
        if(!isGameOver)
        {
            score += value;
        }
    }

    public void EndGame() // player가 사망 시, 수행될 메서드
    {
        isGameOver = true;
    }
}
