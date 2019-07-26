using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    Text myText;

	void Start () {
        myText = GetComponent<Text>();
	}

	void Update () {
        if (PlayerPrefs.HasKey("highscore"))
            myText.text = PlayerPrefs.GetFloat("highscore", 0).ToString();
        else
            myText.text = "NaN";
    }

    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("highscore");
    }
}
