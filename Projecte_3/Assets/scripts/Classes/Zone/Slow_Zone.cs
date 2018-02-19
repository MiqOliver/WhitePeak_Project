using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Zone : Zone
{
    [Range(1.25f, 2.0f)]
    public float slowCoeficient;

    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
            player.maxSpeed /= slowCoeficient;
    }

    protected override void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
            player.maxSpeed *= slowCoeficient;
    }
}
