using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletBehavior : MonoBehaviour {

    public float velocity;

    private void Awake()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Use this for initialization
    void Start () {
        Destroy(this, 4);
        this.GetComponent<Rigidbody>().velocity = velocity * this.transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(this);
    }
}
