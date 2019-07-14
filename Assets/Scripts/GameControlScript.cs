using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour {

    public float timer = 0f;
    public bool gameOver;

	void Start () {
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            gameOver = false;
        }
    }
	
	void Update () {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        if(!gameOver)
        {
            timer += Time.deltaTime;
        }
    }
}
