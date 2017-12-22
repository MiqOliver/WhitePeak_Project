﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{

    protected Transform target;

    //Constructor
    public Enemy()
    {

    }

    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    //Funcions comuns a tots els fills, s'implementen AQUI
    #region Common functions

    public void Die() {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" && collision.gameObject.GetComponent<PlayerBehavior>().killEnemy)
            Die();
        else if (collision.transform.tag == "Player")
            collision.gameObject.GetComponent<PlayerBehavior>().Die();
    }

    #endregion

    //Funcions que hereden els fills, han de ser abstractes
    #region Herencia

    public abstract void Attack();
    protected abstract void Start();
    protected abstract void Update();

    #endregion

}
