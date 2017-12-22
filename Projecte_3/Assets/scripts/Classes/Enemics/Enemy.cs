using System.Collections;
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

#endregion

    //Funcions que hereden els fills, han de ser abstractes
#region Herencia

    public abstract void Attack();
    protected abstract void Start();
    protected abstract void Update();

    #endregion

}
