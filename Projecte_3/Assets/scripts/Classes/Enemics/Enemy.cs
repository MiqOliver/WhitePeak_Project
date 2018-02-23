using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{

    protected PlayerBehavior target;

    [Header("Attack")]
    [SerializeField][Range(1.0f, 5.0f)]
    protected float attackCooldown;
    [SerializeField][Range(2.5f, 10.0f)]
    protected float range;
    protected bool canAttack = true;

    [Space][Header("Run")]
    [SerializeField][Range(1.0f, 5.0f)]
    private float distance;
    [SerializeField][Range(0.25f, 3.0f)]
    private float distanceDecrease;
    [SerializeField][Range(0.5f, 2.5f)]
    private float runLerp;
    protected bool run = true;

    //Constructor
    public Enemy()
    {

    }

    //Funcions comuns a tots els fills, s'implementen AQUI
    #region Common functions

    public void Die() {
        Destroy(this.gameObject);
    }

    public void Run()
    {
        Vector3 desiredPosition = target.transform.position + target.transform.forward * distance;
        desiredPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, runLerp);
    }

    //Corroutines
    protected IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        distance -= distanceDecrease;
        canAttack = true;
    }
    protected IEnumerator RunCooldown()
    {
        run = false;
        yield return new WaitForSeconds(1);
        run = true;
    }

    #endregion

    //Funcions que hereden els fills, han de ser abstractes
    #region Herencia

    public abstract void Attack();
    protected abstract void Awake();
    protected abstract void Start();
    protected abstract void Update();
    protected abstract void OnTriggerEnter(Collider collision);

    #endregion
}
