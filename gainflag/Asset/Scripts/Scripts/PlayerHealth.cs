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

    private Renderer[] playerRenderer;

    void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        playerMove = GetComponent<PlayerMovement>();
        playerShot = GetComponent<PlayerShooter>();

        playerRenderer = GetComponentsInChildren<Renderer>();
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

    public override void Damage(float value,Vector3 hitPoint,Vector3 hitNormal)
    {
        if(!dead)//사망하지 않은 경우
        {
            audioPlayer.PlayOneShot(hitClip);
            StartCoroutine("DamageEffect");
        }

        base.Damage(value,hitPoint,hitNormal);
        UIManager.uInstance.setPlayerHp(health);
    }

    public override void Die()
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
        for (int i = 0; i < playerRenderer.Length; i++)
        {
            playerRenderer[i].material.color = Color.gray;
        }

        yield return new WaitForSeconds(.05f);

        for (int i = 0; i < playerRenderer.Length; i++)
        {
            playerRenderer[i].material.color = Color.white;
        }

    }


}
