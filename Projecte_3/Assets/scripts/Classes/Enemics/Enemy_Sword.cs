using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sword : Enemy
{
    private bool hasShield;
    private bool canAttack;
    public float view_distance_player;
    //Cosntructor
    public Enemy_Sword()
    {

    }

    public void viewDistancePlayer()
    {
        if(Vector3.Distance(target.transform.position, this.transform.position) <= view_distance_player && canAttack)
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

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (!hasShield && target.onTap == PlayerMechanics.Hit && !target.canTap)
            {
                Die();
            }
            else
                collision.gameObject.GetComponent<PlayerBehavior>().Die();

        }
        if (collision.transform.tag == "Projectil")
        {
            if (hasShield)
            {
                hasShield = false;
            }
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
}
