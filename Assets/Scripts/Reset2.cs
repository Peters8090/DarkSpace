using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset2 : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void OnButtonClick()
    {
        PlayerPrefs.DeleteKey("highscore");
    }
}
