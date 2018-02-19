using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lance : Enemy
{
    public PlayerBehavior _player;
    public float view_player_distance;
    private bool can_attack;
    //Cosntructor
    public Enemy_Lance()
    {

    }

    //Funcions heredades
    public override void Attack()
    {
        if (target.onTap == PlayerMechanics.Hit && !target.canTap)
        {
            Die();
        }//si el tap del target correspon al Roll i no el pot fer(per tant vol dir que lesta fent)
    }

    protected override void Start()
    {
        throw new System.NotImplementedException();
    }

    private void viewDistance()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) <= view_player_distance && can_attack)
        {
            Attack();
            can_attack = false;//nomes ataca un cop ya que quan sobrepasa lenemic no li torna a atacar
        }
    }

    private bool isHit()
    {
        if (OnCollisionEnter())
        {

        }
        return false;
    }
    protected override void Update()
    {
        viewDistance();
    }
}
