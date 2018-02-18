using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class PlayerMechanics {
    /// <summary>
    /// Funcio per al moviment del player
    /// </summary>
    /// <param name="player">El player al que se li ha d'aplicar el moviment</param>
    public static void Move(PlayerBehavior player)
    {
        PathManager path = GameObject.Find("Path").GetComponent<PathManager>();
        //Path following
        path.ReachedPoint(player);
        Vector3 v = path.PathFollowing(player);

        //Rotation
        player.transform.rotation = Quaternion.LookRotation(v, player.transform.up);

        //Mechanics limitation
        path.ReachedConstrainPointPoint(player);
        if (path.MechanicConstrains(player))
        {
            player.StopAllCoroutines();
            Debug.Log("Mechanics constrained");
            player.canTap = false;
            player.canDrag = false;
            path.constrain = true;
            path.StartCoroutine(path.ResetMechanics(player));
        }

        //Setting velocity
        player.GetComponent<Rigidbody>().velocity = new Vector3(v.x, player.GetComponent<Rigidbody>().velocity.y, v.z);
    }

    /// <summary>
    /// Funcio per al salt del player
    /// </summary>
    /// <param name="player">El player al que se li ha d'aplicar el salt</param>
    public static void Jump(PlayerBehavior player)
    {
        player.changeMovement = true;
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * player.tapForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Funció per al dash del jugador
    /// </summary>
    /// <param name="player">El player al que se li ha d'aplicar el dash</param>
    public static void Dash(PlayerBehavior player)
    {
        Vector3 drag = new Vector3(InputManager.dragDirection.x * player.transform.forward.x, InputManager.dragDirection.y, InputManager.dragDirection.x * player.transform.forward.z).normalized;
        player.GetComponent<Rigidbody>().AddForce(drag * player.dragDistance, ForceMode.Impulse);

        player.killEnemy = true;
        player.changeMovement = true;
    }

    /// <summary>
    /// Funció per al hit del personatge
    /// </summary>
    /// <param name="player"></param>
    public static void Hit(PlayerBehavior player)
    {
        player.breakRock = true;
        player.killEnemy = true;
    }

    /// <summary>
    /// Funció per a llançar un objecte
    /// </summary>
    /// <param name="player"></param>
    public static void ThrowObject(PlayerBehavior player)
    {
        Vector3 drag = new Vector3(InputManager.dragDirection.x * player.transform.forward.x, InputManager.dragDirection.y, InputManager.dragDirection.x * player.transform.forward.z).normalized;
        player.bulletPrefab.GetComponent<BulletBehavior>().direction = drag;
        GameObject.Instantiate(player.bulletPrefab, player.transform.position, player.transform.rotation);
    }
}
