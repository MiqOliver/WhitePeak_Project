﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class SceneSwitcher : MonoBehaviour { 

    public static void changeToScene(string sceneName)
    {

        GameObject player = MainMenu.getObje();
        // player.transform.parent = null;
        // player.name = "Player";
        // player.GetComponent<PlayerBehavior>().enabled = true;
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(sceneName);
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(sceneName));
        //// UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects()[SceneManager.GetActiveScene().GetRootGameObjects().Length - 1];
        // if (sceneName == "a")
        // { 
        //     //GameObject player = GameObject.Instantiate(prova, new Vector3(76.9f, 0.2f, -89.7f), Quaternion.AngleAxis(-55.7f,Vector3.up));
        // }

    }

}
