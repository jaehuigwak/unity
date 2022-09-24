using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 TODO
correct enemy damage effect error 
 */


public class Enemy : LivingEntity
{
    private LayerMask whatIsTarget;

    private LivingEntity targetEntity;
    private NavMeshAgent pathFinder;
    private Animator enemyAnimator;
    private AudioSource enemyAudioPlayer;

    //[SerializeField] ParticleSystem hitEffect;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip hitSound;

    [SerializeField] float damage = 5f;
    [SerializeField] float timeBetAttack = .5f;
    private float lastAttackTime;

    [SerializeField] float maxDistance = 5f;

    private Vector3 returnPos;
    private bool checkDistance;

    private bool hasTarget
    {
        get
        {
            if (targetEntity != null && !targetEntity.dead && checkDistance)
            {
                return true;
            }

            return false;
        }
    }


    void Awake()
    {

        whatIsTarget = LayerMask.GetMask("Player");
        pathFinder = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
        enemyAudioPlayer = GetComponent<AudioSource>();

        lastAttackTime = 0;
        checkDistance = false;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        lastAttackTime = 0;

        pathFinder.enabled = true;
        StartCoroutine("UpdatePath");
    }


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("enemy health :" + health);
    }

    // Update is called once per frame
    void Update()
    {
        Targeting();
    }

    private IEnumerator UpdatePath()
    {
        while (!dead)
        {
            if (hasTarget)
            {
                pathFinder.isStopped = false;
                pathFinder.SetDestination(targetEntity.transform.position);
            }
            else
            {
                pathFinder.isStopped = true;
                //maxDistance 반경 안의 player 색출.
                Collider[] colliders = Physics.OverlapSphere(transform.position, maxDistance, whatIsTarget);

                for (int i = 0; i < colliders.Length; i++)
                {
                    //dead가 false인 LivingEntity 찾기
                    LivingEntity entity = colliders[i].GetComponent<LivingEntity>();

                    if (entity != null && !entity.dead)
                    {
                        targetEntity = entity;
                        break;
                    }
                }
            }

            enemyAnimator.SetBool("HasTarget", hasTarget);
            yield return new WaitForSeconds(.25f);
        }
    }

    public override void Damage(float value,Vector3 hitPoint,Vector3 hitNormal)
    {
        if (!dead)
        {
            //hitEffect.transform.position = hitPoint;
            //hitEffect.transform.rotation = Quaternion.LookRotation(hitNormal);

            Debug.Log("Enemy health : "+health);
            //hitEffect.Play();
            enemyAudioPlayer.PlayOneShot(hitSound);
            enemyAnimator.SetTrigger("GetHit");
        }

        base.Damage(value,hitPoint,hitNormal);
        UIManager.uInstance.setEnemyHp(health);
    }

    public override void Die()
    {
        base.Die();

        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }

        pathFinder.isStopped = true;
        pathFinder.enabled = false;

        enemyAnimator.SetTrigger("Die");
        enemyAudioPlayer.PlayOneShot(deathSound);
    }

    private void OnTriggerStay(Collider other) //Attack
    {
        if (!dead && Time.timeSinceLevelLoad >= lastAttackTime + timeBetAttack)
        {
            LivingEntity attackTarget = other.GetComponent<LivingEntity>();

            if (attackTarget != null && attackTarget == targetEntity)
            {
                lastAttackTime = Time.timeSinceLevelLoad;

                //상대방의 피격 위치/방향 계산.
                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitNormal = other.transform.position;

                attackTarget.Damage(damage,hitPoint,hitNormal);

                if(!attackTarget.dead)
                {
                    enemyAnimator.SetBool("bAttack", true);
                }
                else
                {
                    enemyAnimator.SetBool("bAttack", false);
                }
            }

            //enemyAnimator.SetBool("bAttack", false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        enemyAnimator.SetBool("bAttack", false);
    }


    private void Targeting()
    {
        if (targetEntity != null)
        {
            float dis = Vector3.Distance(targetEntity.transform.position, transform.position);

            //플레이어와의 거리가 일정 거리 이상 차이나는 경우 or 플레이어와 일정 거리 이상 가까워진 경우
            if (dis > maxDistance)
            {
                checkDistance = false;
            }
            else
            {
                checkDistance = true;
            }
        }

    }
}
