using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sword : Enemy
{
    private bool hasShield;
    //Cosntructor
    public Enemy_Sword()
    {

    }

    public void viewDistancePlayer()
    {
        if(Vector3.Distance(target.transform.position, this.transform.position) <= range && canAttack)
        {
            Attack();
            canAttack = false;
        }
    }
    //public void viewDistanceProjectile() { }:
    //Funcions heredades
    public override void Attack()
    {
        if (hasShield)//si te escut lanimacio de atac sera diferent qe si no la te
        {

        }
        else { }

    }

    protected override void OnTriggerEnter(Collider collision)
    {
    //    if (collision.transform.tag == "Player")
    //    {
    //        if (!hasShield && target.onTap == PlayerMechanics.Hit && !target.canTap)
    //        {
    //            Die();
    //        }
    //        else
    //            collision.gameObject.GetComponent<PlayerBehavior>().Die();

    //    }
        if (collision.transform.tag == "Projectil")
        {
            if (hasShield)
            {
                hasShield = false;
            }
        }
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

        }
    }


    protected override void Start()
    {
        canAttack = true; 
        hasShield = true;
        target = GameObject.Find("Player").transform.GetComponent<PlayerBehavior>();
    }

    protected override void Update()
    {
        viewDistancePlayer(); 
    }

    protected override void Awake()
    {
        //throw new System.NotImplementedException();
    }
}
