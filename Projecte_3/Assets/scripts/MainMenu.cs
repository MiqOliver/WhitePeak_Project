using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject[] characterList;
    public static GameObject player;
    [HideInInspector]
    static int index;

    private void Awake()
    {
        //toogle off their renderer
        for (int i = 0; i< characterList.Length; i++)
            characterList[i].SetActive(false);

        //Debug.Log(characterList.Length);
    }

    private void Start()
    {
        index = 0;
        //characterList = new GameObject[characterList.Length];

        //for (int i = 0; i < transform.childCount; i++)//every children object i have
        //    characterList[i] = transform.GetChild(i).gameObject;



        //Debug.Log("ara" + characterList.Length);
        //if (characterList[index])
        //characterList[index].SetActive(true);
    }

    public void ToogleLeft()
    {
        //toggle off the current moel 
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = characterList.Length - 1;

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
            index = 0;

        //toggle on the new model
        characterList[index].SetActive(true);
        player = characterList[index];
    }

    public void PlayButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneSwitcher.changeToScene("a");
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
