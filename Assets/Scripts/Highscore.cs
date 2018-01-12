using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        GetComponent<Text>().text = PlayerPrefs.GetFloat("highscore", 0).ToString();
	}
}
