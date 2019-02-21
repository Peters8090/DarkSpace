using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void OnButtonClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
