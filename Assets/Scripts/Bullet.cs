﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    private GameControlScript control;
    /// <summary>
    /// When it gets lower, the bullet speed gets higher
    /// </summary>
    float speedDivider = 250f;

    void Start()
    {
        control = GameObject.Find("GameControlObject").GetComponent<GameControlScript>();
    }

    void Update()
    {
        transform.SetParent(GameObject.Find("Canvas").transform);

        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            transform.LookAt(GameObject.Find("Player").transform);
            transform.Translate(transform.forward * Screen.width / speedDivider);
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
        }
        
        transform.localScale = Vector3.one;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().buildIndex.ToString());
            GameObject.Find("Canvas").GetComponent<Lose>().enabled = true;

            if(control != null)
                control.gameOver = true;

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
