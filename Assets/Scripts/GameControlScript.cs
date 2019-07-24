using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {

    public static float timer = 0f;
    public static bool gameOver;

	void Start () {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            gameOver = false;
            timer = 0;
        }
    }
	
	void Update () {
        if(!gameOver)
        {
            timer += Time.deltaTime;
        }
    }
}
