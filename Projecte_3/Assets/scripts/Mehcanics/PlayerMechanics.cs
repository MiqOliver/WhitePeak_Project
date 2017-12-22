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
        player.GetComponent<Rigidbody>().velocity = new Vector3(
            player.transform.forward.x * player.speed,
            player.GetComponent<Rigidbody>().velocity.y,
            player.transform.forward.z * player.speed);
    }

    /// <summary>
    /// Funcio per al salt del player
    /// </summary>
    /// <param name="player">El player al que se li ha d'aplicar el salt</param>
    public static void Jump(PlayerBehavior player)
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * player.tapForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Funció per al dash del jugador
    /// </summary>
    /// <param name="player">El player al que se li ha d'aplicar el dash</param>
    public static void Dash(PlayerBehavior player)
    {
        //Vector3 dash = direction * distance;
        //Vector3 dash = new Vector3(-0.1f, 0.5f, 0);
        Vector3 dash = new Vector3(InputManager.dashDirection.x * player.transform.forward.x, InputManager.dashDirection.y, InputManager.dashDirection.x * player.transform.forward.z).normalized;
        player.GetComponent<Rigidbody>().AddForce(dash * player.dragDistance, ForceMode.Impulse);
        //player.transform.position += dash;
    }
}
