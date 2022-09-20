using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] int totalRemain = 20; //��ü ���� ź��
    [SerializeField] int magCapacity = 5; //źâ �뷮
    [SerializeField] int currentRemain; //���� źâ �뷮�� ���� ź��

    [SerializeField] float timeBetFire = .12f; //�߻� ����
    [SerializeField] float reloadTime = 1.8f; //������ �ҿ�ð�
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
