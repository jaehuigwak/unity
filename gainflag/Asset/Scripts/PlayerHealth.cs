using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip itemPickClip;

    private AudioSource audioPlayer;
    private Animator anim;

    private PlayerMovement playerMove;
    private PlayerShooter playerShot;

    private int cnt = 0;

    void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        playerMove = GetComponent<PlayerMovement>();
        playerShot = GetComponent<PlayerShooter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerMove.enabled = true;
        playerShot.enabled = true;
    }

    public override void RestoreHealth(float value)
    {
        base.RestoreHealth(value);
    }

    public override void Damage(float value)
    {
        if(!dead)//사망하지 않은 경우
        {
            audioPlayer.PlayOneShot(hitClip);
            DamageEffect();
        }

        base.Damage(value);
    }

    protected override void Die()
    {
        base.Die();

        audioPlayer.PlayOneShot(deathClip);
        anim.SetTrigger("Die");

        playerMove.enabled = false;
        playerShot.enabled = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!dead)
        {
            IItem item = other.GetComponent<IItem>();
            if(item != null)
            {
                item.Use(gameObject);
                audioPlayer.PlayOneShot(itemPickClip);
            }
        }
    }

    private IEnumerator DamageEffect()
    {
        while(cnt<3)
        {
            gameObject.SetActive(false);
            yield return new WaitForSeconds(.2f);
            gameObject.SetActive(true);
        }
    }

}
