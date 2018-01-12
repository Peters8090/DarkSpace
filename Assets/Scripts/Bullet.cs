using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour {

    private GameControlScript control;

    void Start () {
        control = GameObject.Find("GameControlObject").GetComponent<GameControlScript>();
    }

	void Update () {
        if (GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            GameObject.Find("Canvas").GetComponent<Lose>().enabled = true;
            Destroy(gameObject);
        }

        transform.SetParent(GameObject.Find("Canvas").transform);

        if(GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            {
                transform.LookAt(GameObject.Find("Player").transform);
            }


            transform.Translate(transform.forward * 10);
        }

        

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().buildIndex.ToString());
            Destroy(coll.gameObject);
            control.gameOver = true;
            Destroy(gameObject);
        }
    }

}
