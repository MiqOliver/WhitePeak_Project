using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamBehavior : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void toSettins()
    {
        anim.SetTrigger("ToSettings");
    }

    public void toMain()
    {
        anim.SetTrigger("ToMenu");
    }

}
