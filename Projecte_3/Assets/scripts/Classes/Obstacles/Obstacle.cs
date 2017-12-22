using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Obstacle : MonoBehaviour {

    //Constructor
    public Obstacle()
    {

    }

    //Funcions comuns a tots els fills, s'implementen AQUI
    #region Common functions

    public void Die()
    {
        this.GetComponent<Collider>().isTrigger = true;
        //Destroy(this.gameObject);
    }

    #endregion

    //Funcions que hereden els fills, han de ser abstractes
    #region Herencia
        


    #endregion
}
