using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamara : MonoBehaviour {


    public void LookAtMenu(Transform menuTranform)
    {
        Camera.main.transform.LookAt(menuTranform.position);
    }
}
