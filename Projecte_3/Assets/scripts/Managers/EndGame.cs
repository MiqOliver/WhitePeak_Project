using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public Text percentage;
    public Text text;
    public Text coins;
    public SceneFader fader;

	// Use this for initialization
	void Start () {
        int per = PlayerPrefs.GetInt("Percentage");
        percentage.text = per.ToString() + "%";
        coins.text = "$" + PlayerPrefs.GetInt("ObtainedCoins").ToString();

        if (per < 10)
            text.text = "NICE TRY... FOR A BEGINNER";
        else if (per < 20)
            text.text = "HEH, GET BETTER";
        else if (per < 30)
            text.text = "NOT GOOD ENOUGH";
        else if (per < 40)
            text.text = "YOU CAN DO BETTER";
        else if (per < 50)
            text.text = "NOT BAD";
        else if (per < 60)
            text.text = "YOU'RE GOOD";
        else if (per < 70)
            text.text = "JUST A LITTLE MORE";
        else if (per < 80)
            text.text = "ALMOST THERE";
        else if (per < 90)
            text.text = "SO CLOSE!";
        else
            text.text = "PERFECT! LEVEL COMPLETE";
    }
	
	public void Menu()
    {
        fader.FadeTo("menu");
    }
    public void Play()
    {
        fader.FadeTo("Level_1");
    }
}
