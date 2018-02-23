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
    [SerializeField]
    [Range(0.05f, 1.0f)]
    private float distanceDecrease;
    [SerializeField][Range(0.05f, 0.5f)]
    private float runLerp;
    [SerializeField][Range(0.5f, 2.5f)]
    private float runCooldown;
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
        float aux = Mathf.Lerp(Vector3.Distance(transform.position, target.transform.position), distance, runLerp);
        Vector3 desiredPosition = target.transform.position + target.transform.forward * aux;
        desiredPosition.y = transform.position.y;
        transform.position = desiredPosition;
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
        yield return new WaitForSeconds(runCooldown);
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
