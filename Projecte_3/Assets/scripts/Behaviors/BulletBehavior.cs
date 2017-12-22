using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletBehavior : MonoBehaviour {

    public float velocity;
    public enum Type { PlayerBullet, EnemyBullet };
    public Type type;
    public float lifeTime;
    [HideInInspector]
    public Vector3 direction;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = false;
    }

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, lifeTime);
        this.GetComponent<Rigidbody>().velocity = velocity * direction;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        switch (type)
        {
            case Type.PlayerBullet:
                if (collision.transform.tag != "Player")
                    Destroy(this.gameObject);
                break;
            case Type.EnemyBullet:
                if(collision.transform.tag == "Player")
                    Destroy(collision.gameObject);
                if(collision.transform.tag != "Enemy")
                    Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(type == Type.PlayerBullet && other.transform.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
