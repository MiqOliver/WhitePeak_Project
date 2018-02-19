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
        if(_player = GetComponent<PlayerBehavior>(target))
    }

    protected override void Start()
    {
        throw new System.NotImplementedException();
    }

    private void viewDistance()
    {
        if (Vector3.Distance(this.transform.position, target.position) <= view_player_distance && can_attack)
        {
            Attack();
            can_attack = false;//nomes ataca un cop ya que quan sobrepasa lenemic no li torna a atacar
        }
    }

    private bool isHit(ref PlayerBehavior player)
    {
        return false;
    }
    protected override void Update()
    {
        viewDistance();
    }
}
