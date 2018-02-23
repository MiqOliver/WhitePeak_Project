using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Archer : Enemy
{
    [Space][SerializeField]
    private GameObject bulletPrefab;
    
    protected Vector3 bulletDirection;

    //Cosntructor
    public Enemy_Archer()
    {

    }

    //Funcions heredades
    public override void Attack()
    {
        bulletDirection = (target.transform.position - transform.position).normalized;
        bulletPrefab.GetComponent<BulletBehavior>().direction = bulletDirection;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    protected override void Start()
    {
        target = GameObject.Find("Player").transform.GetComponent<PlayerBehavior>();
    }

    protected override void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= range)
        {
            if (canAttack)
            {
                Attack();
                StartCoroutine(AttackCooldown());
                StartCoroutine(RunCooldown());
            }
            else if(run)
                Run();
        }
    }

    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player" && collision.gameObject.GetComponent<PlayerBehavior>().killEnemy)
            Die();
        else if (collision.transform.tag == "Player")
            collision.gameObject.GetComponent<PlayerBehavior>().Die();
        else if (collision.transform.tag == "Ground")
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Ground")
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }



    protected override void Awake()
    {
        enabled = true;
    }
}
