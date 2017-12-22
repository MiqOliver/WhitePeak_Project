using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher: MonoBehaviour {
    
    public void changeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if(sceneName == "a")
        {
           // GameObject player = Instantiate("prefab")
        }
    }
}
