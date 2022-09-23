using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : MonoBehaviour,IDamagable
{
    [SerializeField] float maxHP = 100.0f;
    public float health { get; private set; }
    public bool dead { get; private set; }
    public event Action onDeath;
    
    protected virtual void OnEnable()
    {
        dead = false;
        health = maxHP;
    }

    public virtual void Damage(float value,Vector3 hitPoint,Vector3 hitNormal)
    {
        if (health <= 0)
            return;

        health -= value;
        if(health<=0 && !dead)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if(onDeath != null)
        {
            onDeath();
        }
        dead = true;
        StartCoroutine("DeadEffect");
        
    }

    public virtual void RestoreHealth(float value)
    {
        if(dead)
        {
            return;
        }

        health += value;
    }

    private IEnumerator DeadEffect()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
}
