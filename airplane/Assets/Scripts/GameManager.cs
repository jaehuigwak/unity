using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public bool playerDead;

    public GameObject gameover;
    public TextMeshProUGUI scoreText;

    private int score;

    public Slider hpBar;

    public GameObject pauseWindow;

    private AudioSource[] audios;

    public int spawnCnt = 0;
    public Spawner spawner;

    public bool bossDie;
    public bool bossCreate;
    public GameObject success;
    public GameObject boss;
    private int count = 0;
    
    void Awake()
    {
        manager = this;
        spawnCnt = 0;
        bossDie = false;
        bossCreate = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("scene start");
        score = 0;
        playerDead = false;
        Time.timeScale = 1;
        audios = GetComponents<AudioSource>();
        gameover.SetActive(false);
        success.SetActive(false);
        spawner = FindObjectOfType<Spawner>();
        spawner.initList();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDead)
        {
            GameOver();
        }
        else if(bossDie)
        {
            StartCoroutine(PlayerWin());
        }

        if(bossCreate)
        {
            StartCoroutine(BossPopUp());
            count++;
        }

        spawnCnt = spawner.getCnt();
        Debug.Log("spawn cnt : " + spawnCnt);
    }

    public void onPlay()
    {
        Time.timeScale = 1;
        pauseWindow.SetActive(false);
    }

    public void onPause()
    {
        pauseWindow.SetActive(true);
        Time.timeScale = 0;
    }

    private void GameOver()
    {
        audios[0].enabled = false;
        audios[1].enabled = true;
        audios[2].enabled = false;

        gameover.SetActive(true);
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = ""+score;
    }

    private IEnumerator PlayerWin()
    {
        audios[0].enabled = false;
        audios[1].enabled = false;  
        audios[2].enabled = true;

        success.SetActive(true);

        yield return new WaitForSeconds(.7f);
        Time.timeScale = 0;
    }

    private IEnumerator BossPopUp()
    {
        if(count==0)
        {
            boss.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            boss.SetActive(false);
        }
    }
}
