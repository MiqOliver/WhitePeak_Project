using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamara : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LookAtMenu(Transform menuTranform)
    {
        Camera.main.transform.LookAt(menuTranform.position);
    }
}
