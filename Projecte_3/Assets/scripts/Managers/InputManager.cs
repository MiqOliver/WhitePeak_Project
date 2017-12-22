using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager {

    private static bool moved = false;
    private static Vector3 initPos = Vector3.zero;
    private static Vector3 finalPos = Vector3.zero;
    public static Vector3 dashDirection = Vector3.zero;

    /// <summary>
    /// Returns true if the user taped any point of the screen at least once
    /// </summary>
    /// <returns></returns>
    public static bool Toched()
    {
    //EDITOR
#if UNITY_EDITOR
        return Input.GetKeyDown(KeyCode.Space);
#endif
    
    //ANDROID
#if UNITY_ANDROID
        return Input.touchCount > 0;
#endif
        return false;
    }
    

    /// <summary>
    /// returns a normalized direction vector of the drag on the screen
    /// </summary>
    /// <returns></returns>
    public static Vector3 Drag()
    {
        //EDITOR
#if UNITY_EDITOR 



        if (Input.GetMouseButtonDown(0))
        {
            initPos = Input.mousePosition;
            moved = true;
            //Debug.Log("Inici del Mouse: " + initPos.x + " " + initPos.y + " " + initPos.z + " ");
        }


        if (Input.GetMouseButtonUp(0) && moved)
        {
            finalPos = Input.mousePosition;
            dashDirection = (finalPos - initPos).normalized;
            moved = false;
            //Debug.Log("Final del Mouse: " + finalPos.x + " " + finalPos.y + " " + finalPos.z + " ");
            //Debug.Log("Vector: " + dashDirection.x  + " " + dashDirection.z + " ");
            if (dashDirection.magnitude > 0) {
                return dashDirection;
                //Debug.Log("Magnitud: " + (vect).magnitude);
            }
        }
        
        return Vector3.zero;
#endif

        //ANDROID
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //Vector3 initPos = touch.position;
            //bool moved = false;

            if(touch.phase == TouchPhase.Moved)
            {
                moved = true;
            }
            if(touch.phase == TouchPhase.Ended && moved)
            {
                return ((Vector3)touch.position - initPos).normalized;
            }
            return Vector3.zero;
        }
#endif
        return Vector3.zero;
    }
}
