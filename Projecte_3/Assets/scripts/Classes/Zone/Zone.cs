using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Zone : MonoBehaviour {

    protected PlayerBehavior player;
    
    //Funcions comuns a tots els fills, s'implementen AQUI
    #region Common functions

    private void Start()
    {
        player = GameObject.Find("Player").transform.GetComponent<PlayerBehavior>();
        GetComponent<BoxCollider>().isTrigger = true;
    }

    #endregion

    //Funcions que hereden els fills, han de ser abstractes
    #region Herencia

    protected abstract void OnTriggerEnter(Collider collision);
    protected abstract void OnTriggerExit(Collider collision);

    #endregion
}
