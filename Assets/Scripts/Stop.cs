using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour {

    private bool stopped;

	void Start () {
        stopped = false;
	}
	
	void Update () {
        if (stopped)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
	}

    public void OnButtonClick()
    {
        stopped = !stopped;
    }
}
