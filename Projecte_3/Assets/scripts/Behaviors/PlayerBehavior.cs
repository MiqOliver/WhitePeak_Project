using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerBehavior : MonoBehaviour {

    #region Variables
    public static PlayerBehavior control;
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
    Animator anim;
    #endregion

    //these are for the mechanics of each character
    public delegate void mechanics(PlayerBehavior behavior);
    public mechanics onTap, onDrag;

    #region ObstacleRelated

    [HideInInspector]
    public bool breakRock;
    [HideInInspector]
    public bool breakLiana;
    [HideInInspector]
    public bool killEnemy;

    #endregion

    private void Awake()
    {
        if (!menu)
        {
            this.character = (playerClass)PlayerPrefs.GetInt("CharacterSelected");
            this.gameObject.name = "Player";
            if (control == null)
            {
                DontDestroyOnLoad(gameObject);
                control = this;
            }
            else if (control != this)
            {
                Destroy(gameObject);
            }

        }
        
    }

    // Use this for initializtion
    void Start () {

        canDrag = true;
        anim = GetComponent<Animator>();
        anim.SetBool("Running", true);
        #region ObstacleRelated

        breakRock = false;
        killEnemy = false;

        #endregion

        switch (character)
        {
            case playerClass.Girl_Name:

                onTap = PlayerMechanics.Jump;
                onDrag = PlayerMechanics.Dash;

                break;
            case playerClass.Big_Name:

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
            canTap = false;
            onTap(this);
        }
        if (InputManager.Drag().x > 0 && canDrag)
        {
            canDrag = false;
            onDrag(this);
            StartCoroutine(DragCooldown(dragCooldown));
        }
    }
    
    public void Save()
    {
        SaveManager.SavePlayer(this);
    }

    public void Load()
    {
        float[] loadStats = SaveManager.LoadPlayer();

        maxForce = loadStats[0];
        maxSpeed = loadStats[1];
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
        breakLiana = false;
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
        breakLiana = false;
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
            GetComponent<Rigidbody>().freezeRotation = false;
            changeMovement = false;
        }
	}

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = true;
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
