using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Lianes : Obstacle
{
    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.transform.GetComponent<PlayerBehavior>().breakLiana)
            {
                this.Die();
                PlayerMechanics.Move(collision.transform.GetComponent<PlayerBehavior>());
            }
            else
                collision.transform.GetComponent<PlayerBehavior>().Die();
        }
    }
}
