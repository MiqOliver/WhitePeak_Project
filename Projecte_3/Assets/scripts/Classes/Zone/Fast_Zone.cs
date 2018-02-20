using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast_Zone : Zone
{
    [Range(1.25f, 2.0f)]
    public float fastenCoeficient;

    protected override void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
            player.maxSpeed *= fastenCoeficient;
    }

    protected override void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
            player.maxSpeed /= fastenCoeficient;
    }
}
