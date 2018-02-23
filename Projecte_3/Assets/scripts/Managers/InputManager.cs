using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager {

    private static bool moved = false;
    private static Vector3 initPos = Vector3.zero;
    private static Vector3 finalPos = Vector3.zero;
    public static Vector3 dragDirection = Vector3.zero;

    /// <summary>
    /// Returns true if the user taped any point of the screen at least once
    /// </summary>
    /// <returns></returns>
    public static bool Toched()
    {
    //EDITOR
//#if UNITY_EDITOR
        return Input.GetKeyDown(KeyCode.Space);
//#endif
    
    //ANDROID
#if UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).position.x <= Screen.width/3)
                return Input.touchCount > 0;
        }
#endif
        return false;
    }
    

    /// <summary>
    /// returns a normalized direction vector of the drag on the screen
    /// </summary>
    /// <returns></returns>
    public static Vector3 Drag()
    {
        if (Input.GetMouseButtonDown(0))
        {
//#if UNITY_EDITOR
            initPos = Input.mousePosition;
            moved = true;
//#endif

#if UNITY_ANDROID
            if (Input.mousePosition.x > Screen.width / 3)
            {
                initPos = Input.mousePosition;
                moved = true;
            }
#endif
        }


        if (Input.GetMouseButtonUp(0) && moved)
        {
            finalPos = Input.mousePosition;
            dragDirection = (finalPos - initPos).normalized;
            moved = false;

            if (dragDirection.magnitude > 0) {
                return dragDirection;
            }
        }
        
        return Vector3.zero;
    }


    //---------------------DEVELOPMENT KEYS--------------------
    public static void DevelopKeys(SceneFader fader)
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            fader.FadeTo("Menu");
        else if (Input.GetKeyDown(KeyCode.Alpha1))
            fader.FadeTo("Level_1");
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            fader.FadeTo("Level_1.2");
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            fader.FadeTo("BridgeCinematic");
    }
}
