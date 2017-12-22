using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerBehavior : MonoBehaviour {

    public enum playerClass { Girl_Name, Big_Name };
    
    [Range(3, 7)]
	public float speed;
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

	private bool isGrounded = false;

    //these are for the mechanics of each character
    private delegate void mechanics(PlayerBehavior behavior);
    private mechanics onTap;
    private mechanics onDrag;

    #region ObstacleRelated

    [HideInInspector]
    public bool breakRock;

    #endregion

    // Use this for initializtion
    void Start () {

        #region ObstacleRelated

        breakRock = true;

        #endregion

        switch (character)
        {
            case playerClass.Girl_Name:
                onTap = PlayerMechanics.Jump;
                onDrag = PlayerMechanics.Dash;
                break;
            case playerClass.Big_Name:
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        PlayerMechanics.Move(this);

        if (InputManager.Toched() && isGrounded)
            {
                //Instantiate(bulletPrefab, this.transform);
                onTap(this);
                isGrounded = false;
            }
            Vector3 drag = InputManager.Drag();
            if (drag.x != 0)
            {
            onDrag(this);
                //PlayerMechanics.Dash(this,  Vector3.zero);
                //PlayerMechanics.Dash(this, 50, drag);
            }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    #region Corroutines

    /// <summary>
    /// Funció que impedeix la mecanica de tap mentre no hagui passat el temps de cooldown
    /// </summary>
    /// <param name="s">Temps a esperar antes de permetrer el salt</param>
    /// <returns></returns>
    IEnumerator TapCooldown(float s) {
        yield return new WaitForSeconds(s);
        isGrounded = true;
    }

    /// <summary>
    /// Funció que impedeix la mecanica de drag mentre no hagui passat el temps de cooldown
    /// </summary>
    /// <param name="s">Temps a esperar antes de permetrer el salt</param>
    /// <returns></returns>
    IEnumerator DragCooldown(float s)
    {
        yield return new WaitForSeconds(s);
        isGrounded = true;
    }

    #endregion

    #region Collision Detection

    void OnCollisionEnter(Collision other)
	{	
		if (other.collider.tag == "Ground") {
            StartCoroutine(TapCooldown(tapCooldown));
            GetComponent<Rigidbody>().useGravity = false;
		}
	}

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    #endregion
}
