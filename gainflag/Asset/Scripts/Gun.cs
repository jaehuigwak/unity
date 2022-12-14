using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 TODO
add ray cast hit 
 */


public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reload
    }

    public State state { get; private set; }

    private GameObject ShootPoint;
    private Light shotEffect;
    private AudioSource audioPlayer;

    [SerializeField] AudioClip shotClip;
    [SerializeField] AudioClip reloadClip;

    [SerializeField] float damage = 20.0f;
    //private float fireDistance = 50.0f;
    [SerializeField] int totalRemain = 20; //전체 남은 탄알
    [SerializeField] int magCapacity = 5; //탄창 용량
    [SerializeField] int currentRemain; //현재 탄창 용량이 남은 탄알

    [SerializeField] float timeBetFire = .12f; //발사 간격
    [SerializeField] float reloadTime = 1.8f; //재장전 소요시간
    private float lastFireTime;

    [SerializeField] GameObject bullet;


    private void Awake()
    {
        ShootPoint = GameObject.Find("ShootPoint");
        shotEffect=ShootPoint.GetComponent<Light>();
        audioPlayer = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        currentRemain = magCapacity;
        lastFireTime = 0;
        shotEffect.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
    }

    private IEnumerator ShotEffect()
    {
        audioPlayer.PlayOneShot(shotClip);
        shotEffect.enabled = true;
        yield return new WaitForSeconds(.05f);
        shotEffect.enabled = false;
    }
    public void Fire()
    {
        Instantiate(bullet, ShootPoint.transform.position, transform.rotation);
        
        StartCoroutine(ShotEffect());
        currentRemain--;
        if(currentRemain <= 0)
        {
            currentRemain = 0;
            state = State.Empty;
        }
    }
}
