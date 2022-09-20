using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : LivingEntity
{
    private UnityEngine.AI.NavMeshAgent pathFinder;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip damageSound;

    [SerializeField] float damage = 5f;
    [SerializeField] float timeBetAttack = .5f;
    private float lastAttackTime;

    void Awake()
    {
        lastAttackTime = 0;
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
