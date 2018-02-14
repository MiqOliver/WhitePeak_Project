using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;

    public string nextLevel;
    public int levelToUnlock = 2;

    public SceneFader sceneFader;


    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;

    }

    void EndGame()
    {
        GameIsOver = true;
       // gameOverUI.setActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Level won!");
        PlayerPrefs.SetInt("levelReahed", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
