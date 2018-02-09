using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerBehavior : MonoBehaviour {

    public enum playerClass { Girl_Name, Big_Name };

    [Range(0.1f, 10)]
    public float maxForce;
    [Range(3, 7)]
	public float maxSpeed;
    [Range(2.5f, 10)]
    public float tapForce;
    [Range(0.1f, 1.0f)]
    public float tapCooldown;
    [Range(1, 10)]
    public float dragDistance;
    [Range(1.0f, 3.0f)]
    public float dragCooldown;
    [Space]
    public GameObject bulletPrefab;
    [Space]
    public playerClass character;
    
    [HideInInspector]
    public bool canTap = false;
    [HideInInspector]
    public bool canDrag = true;
    [HideInInspector]
    public bool changeMovement = false;

    [Space]
    public bool menu = false;

    //these are for the mechanics of each character
    private delegate void mechanics(PlayerBehavior behavior);
    private mechanics onTap, onDrag;

    #region ObstacleRelated

    [HideInInspector]
    public bool breakRock;
    [HideInInspector]
    public bool killEnemy;

    #endregion

    private void Awake()
    {
        if (!menu)
        {
            this.character = (playerClass)PlayerPrefs.GetInt("CharacterSelected");
            this.gameObject.name = "Player";
        }

    }

    // Use this for initializtion
    void Start () {

        #region ObstacleRelated

        breakRock = false;
        killEnemy = false;

        #endregion

        switch (character)
        {
            case playerClass.Girl_Name:

                maxSpeed = 4;
                tapForce = 5;
                tapCooldown = 0.35f;
                dragDistance = 6;
                dragCooldown = 3;

                onTap = PlayerMechanics.Jump;
                onDrag = PlayerMechanics.Dash;

                break;
            case playerClass.Big_Name:

                maxSpeed = 3;
                tapForce = 5;
                tapCooldown = 1;
                dragDistance = 10;
                dragCooldown = 2.5f;

                onTap = PlayerMechanics.Hit;
                onDrag = PlayerMechanics.ThrowObject;

                break;
            default:
                break;
        }   
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        if(!changeMovement)
            PlayerMechanics.Move(this);

        if (InputManager.Toched() && canTap)
        {
            onTap(this);
            canTap = false;
        }
        Vector3 drag = InputManager.Drag();
        if (drag.x != 0)
        {
            onDrag(this);
            canDrag = false;
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        SceneSwitcher.changeToScene("menu");
    }

    #region Corroutines

    /// <summary>
    /// Funció que impedeix la mecanica de tap mentre no hagui passat el temps de cooldown
    /// </summary>
    /// <param name="s">Temps a esperar antes de permetrer el salt</param>
    /// <returns></returns>
    public IEnumerator TapCooldown(float s) {
        yield return new WaitForSeconds(s);
        canTap = true;

        breakRock = false;
        killEnemy = false;
    }

    /// <summary>
    /// Funció que impedeix la mecanica de drag mentre no hagui passat el temps de cooldown
    /// </summary>
    /// <param name="s">Temps a esperar antes de permetrer el salt</param>
    /// <returns></returns>
    public IEnumerator DragCooldown(float s)
    {
        yield return new WaitForSeconds(s);
        canDrag = true;

        breakRock = false;
        killEnemy = false;
    }

    #endregion

    #region Collision Detection
    
    //COLLISIONS
    void OnCollisionEnter(Collision other)
	{	
		if (other.collider.tag == "Ground") {
            StartCoroutine(TapCooldown(tapCooldown));
            GetComponent<Rigidbody>().useGravity = false;
            changeMovement = false;
        }
	}

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    //TRIGGERS
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            if (killEnemy)
                Destroy(other.gameObject);
            else
                Die();
        }
    }

    #endregion
}
