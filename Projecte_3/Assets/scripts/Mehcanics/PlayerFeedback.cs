using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class PlayerFeedback {

    /// <summary>
    /// Funció pel feedback de que es pot emprar el tap
    /// </summary>
    /// <param name="player"></param>
	public static void Tap(PlayerBehavior player)
    {
        player.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
    }

    /// <summary>
    /// Funció pel feedback de que es pot emprar el drag
    /// </summary>
    /// <param name="player"></param>
    public static void Drag(PlayerBehavior player)
    {
        player.transform.GetChild(3).GetComponent<ParticleSystem>().Play();
    }
}
