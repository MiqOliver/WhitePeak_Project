using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lance : Enemy
{
    public float view_player_distance;
    private bool can_attack = true;
    //Cosntructor
    public Enemy_Lance()
    {

    }

    //Funcions heredades
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Start()
    {
        target = GameObject.Find("Player").transform.GetComponent<PlayerBehavior>();
    }

    private void viewDistance()
    {
        if ((Vector3.Distance(this.transform.position, target.transform.position) <= view_player_distance) && can_attack)
        {
            Attack();
            can_attack = false;//nomes ataca un cop ya que quan sobrepasa lenemic no li torna a atacar
            Debug.Log("AVISTAT I ATACO");
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")//si la colisio es amb el player
        {
            if ((target.onTap == PlayerMechanics.Hit && !target.canTap) || (target.onDrag == PlayerMechanics.Dash && !target.canDrag))
                //si el player actual es lhome, i no pot fer el Roll
                //amb el tap, vol dir que lesta utilitzant en aquell moment, per tant
                //morira
            {
                Debug.Log("ENEMIC MOR");
                Die();           
            }
            else//sino morira el player
            {
                collision.gameObject.GetComponent<PlayerBehavior>().Die();
                Debug.Log("NO HA FET ROLL, MOR EL PLAYER");
            }
        }

       // if(collision.transform.tag == "Proyectil")//encara re disenyat per aixo
    }

    protected override void Update()
    {
        viewDistance();
    }
}
