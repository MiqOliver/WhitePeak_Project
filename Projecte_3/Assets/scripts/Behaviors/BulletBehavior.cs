using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletBehavior : MonoBehaviour {

    public float velocity;
    [HideInInspector]
    public Vector3 direction;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = false;
    }

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody>().velocity = velocity * direction;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
            Destroy(collision.gameObject);
        if(collision.transform.tag != "Enemy")
            Destroy(this.gameObject);
    }
}
