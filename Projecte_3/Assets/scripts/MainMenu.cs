using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [HideInInspector]
    static GameObject[] characterList;
    [HideInInspector]
    static int index;
    
    
    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)//every children object i have
            characterList[i] = transform.GetChild(i).gameObject;


        //toogle off their renderer
        foreach (GameObject go in characterList)
            go.SetActive(false);

        if (characterList[index])
            characterList[index].SetActive(true);
    }

    public void ToogleLeft()
    {
        //toggle off the current moel 
        characterList[index].SetActive(false);
        Debug.Log(SceneManager.GetActiveScene().name);
        index--;
        if (index < 0)
            index = characterList.Length - 1;

        //toggle on the new model
        characterList[index].SetActive(true);
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
        return characterList[index];
        
    }


}
