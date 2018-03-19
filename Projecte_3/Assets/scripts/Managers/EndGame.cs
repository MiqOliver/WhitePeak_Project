using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public Text percentage;

	// Use this for initialization
	void Start () {
        percentage.text = PlayerPrefs.GetInt("Percentage").ToString() + "%";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
