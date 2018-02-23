using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject[] characterList;
    public static GameObject player;

    public SceneFader sceneFader;
    [HideInInspector]
    static int index;

    //implementar per beta skills player segons static int tap, drag;

    private void Awake()
    {
        //toogle off their renderer

        characterList[1].SetActive(false);  
         
    }

    private void Start()
    {
        index = 0;
       // Debug.Log(characterList[index]);
        textAboutPlayer();
        //characterList = new GameObject[characterList.Length];

        //for (int i = 0; i < transform.childCount; i++)//every children object i have
        //    characterList[i] = transform.GetChild(i).gameObject;


        //if (characterList[index])
        //characterList[index].SetActive(true);
    }

    public void ToogleLeft()
    {
        //toggle off the current moel 
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        textAboutPlayer();
            
        //toggle on the new model
        characterList[index].SetActive(true);
        player = characterList[index];
    }
    public void ToogleRight()
    {
        //toggle off the current moel 
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        textAboutPlayer();
        //toggle on the new model
        characterList[index].SetActive(true);
        player = characterList[index];
    }

    public void textAboutPlayer()
    {
        if(index % 2 == 0)
        {
            Text name = GameObject.Find("PlayerName").GetComponentInChildren<Text>();
            name.text = "GIRL";
            Text description = GameObject.Find("Player Description").GetComponentInChildren<Text>();
            description.text = "1st character";
            Text hability1 = GameObject.Find("PlayerHab1").GetComponentInChildren<Text>();
            hability1.text = "DASH";
            Text hability2 = GameObject.Find("PlayerHab2").GetComponentInChildren<Text>();
            hability2.text = "JUMP";
        }
        else
        {
            Text name = GameObject.Find("PlayerName").GetComponentInChildren<Text>();
            name.text = "BOY";
            Text description = GameObject.Find("Player Description").GetComponentInChildren<Text>();
            description.text = "2nd character";
            Text hability1 = GameObject.Find("PlayerHab1").GetComponentInChildren<Text>();
            hability1.text = "ROLL";
            Text hability2 = GameObject.Find("PlayerHab2").GetComponentInChildren<Text>();
            hability2.text = "THROW OBJECT";
        }
    }
    public void PlayButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        sceneFader.FadeTo("Level_1");
      //  SceneSwitcher.changeToScene("a");
        //SceneManager.GetActvieScene().buildIndex + 1
    }
    
    public void exit()
    {
        Application.Quit();
    }

    public static GameObject getObje()
    {
        return player;

    }


}
