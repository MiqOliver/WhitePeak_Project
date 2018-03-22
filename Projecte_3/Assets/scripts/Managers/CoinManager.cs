using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

    private int coins;
    public Text coin_text;
    [Range(1, 3)]
    public float show_time;

    private void Awake()
    {
        coins = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ModifyCoins(10);
            Debug.Log("pene");
        }
    }

    public void WriteCoins()
    {
        PlayerPrefs.SetInt("ObtainedCoins", coins);
        PlayerPrefs.SetInt("Coins", coins + PlayerPrefs.GetInt("Coins"));
    }
    public void ModifyCoins(int i)
    {
        coins += i;
        coin_text.text = "$" + coins.ToString();
        StartCoroutine(CoinFeedback());
    }
    private IEnumerator CoinFeedback()
    {
        coin_text.gameObject.SetActive(true);
        yield return new WaitForSeconds(show_time);
        coin_text.gameObject.SetActive(false);
    }
}
