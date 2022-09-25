using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 TODO

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
    private float fireDistance = 50.0f;//사정 거리

    [SerializeField] int totalRemain = 20; //전체 남은 탄알
    [SerializeField] int magCapacity = 10; //탄창 용량
    private int currentRemain; //현재 탄창 용량이 남은 탄알

    [SerializeField] float timeBetFire = .2f; //발사 간격
    [SerializeField] float reloadTime = 1.8f; //재장전 소요시간
    private float lastFireTime;

    [SerializeField] GameObject bullet;


    private void Awake()
    {
        ShootPoint = GameObject.Find("ShootPoint");
        shotEffect=ShootPoint.GetComponent<Light>();
        audioPlayer = GetComponent<AudioSource>();

        UIManager.uInstance.setRemainAmmoText(totalRemain);
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
        if(state==State.Ready && Time.timeSinceLevelLoad>=lastFireTime+timeBetFire)
        {
            lastFireTime = Time.timeSinceLevelLoad;
            Shot();
        }
       
    }

    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPos = Vector3.zero;

        if(Physics.Raycast(ShootPoint.transform.position,ShootPoint.transform.forward,out hit,fireDistance))
        {
            IDamagable target = hit.collider.GetComponent<IDamagable>();

            if(target != null)
            {
                Debug.Log("shot");
                //target.Damage(damage, hit.point, hit.normal); ->  bullet에서 Damage 처리
                hitPos= hit.point;

            }
            else
            {
                hitPos = ShootPoint.transform.position + ShootPoint.transform.forward * fireDistance;
            }

            GameObject cloneBullet=Instantiate(bullet, ShootPoint.transform.position, transform.rotation);
            cloneBullet.GetComponent<Bullet>().SetBulletForward(hitPos);

            StartCoroutine(ShotEffect());

            currentRemain--;
            if (currentRemain <= 0)
            {
                currentRemain = 0;
                state = State.Empty;
            }
        }
    }

    public void Reload()
    {
        Debug.Log("Gun Reload");
        if(state==State.Reload || totalRemain<=0 || currentRemain>=magCapacity )
        {
            //이미 재장전 중인 경우, 남은 탄알이 없는 경우, 탄알이 이미 가득 찬 경우
            return;
        }
        StartCoroutine("ReloadRoutine");
        StartCoroutine(UIManager.uInstance.ValidShotTimer(reloadTime));
    }

    private IEnumerator ReloadRoutine()
    {
        state = State.Reload;
        UIManager.uInstance.ShotButtonInvalidEffect();

        int fillCnt = magCapacity - currentRemain;

        if (totalRemain < fillCnt) // 남은 탄알보다 채워야할 탄알이 많은 경우
        {
            fillCnt = totalRemain;
        }

        currentRemain += fillCnt;
        totalRemain -= fillCnt;
        UIManager.uInstance.setRemainAmmoText(totalRemain);

        yield return new WaitForSeconds(reloadTime);

        state = State.Ready;
        UIManager.uInstance.ShotButtonValidEffect();
    }
}
