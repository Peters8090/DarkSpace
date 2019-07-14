using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    private float timer = 0;
    private float highscore;
    
	void Update () {
        timer = GameObject.Find("GameControlObject").GetComponent<GameControlScript>().timer;
        timer = Mathf.Round(timer * 100f) / 100f;
        GetComponent<Text>().text = timer.ToString();

        if (!PlayerPrefs.HasKey("highscore"))
        {
            highscore = timer;
            PlayerPrefs.SetFloat("highscore", highscore);
        }

        if (timer < PlayerPrefs.GetFloat("highscore"))
        {
            highscore = timer;
            PlayerPrefs.SetFloat("highscore", highscore);
        }
	}
}
