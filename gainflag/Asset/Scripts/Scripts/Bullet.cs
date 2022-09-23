using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField] float force = 10;
    [SerializeField] float damageGuage = 20f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid.AddForce(transform.forward*force, ForceMode.Impulse);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeDamageGuage(float value)
    {
        damageGuage = value;
    }

    void OnTriggerEnter(Collider other) 
    {
        LivingEntity attackTarget = other.GetComponent<LivingEntity>();
        if(attackTarget != null)
        {
            Vector3 hitpos = other.ClosestPoint(transform.position);
            Vector3 hitnor = other.transform.position;

            attackTarget.Damage(damageGuage, hitpos, hitnor);
            Destroy(gameObject);
        }
    }
}
