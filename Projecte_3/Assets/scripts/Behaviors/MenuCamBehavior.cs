using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamBehavior : MonoBehaviour {

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void toSettins()
    {
        anim.SetTrigger("ToSettings");
    }

    public void toMain()
    {
        anim.SetTrigger("ToMenu");
    }

    public void toLevelSelection()
    {
        anim.SetTrigger("ToLevelSelection");
    }

}
