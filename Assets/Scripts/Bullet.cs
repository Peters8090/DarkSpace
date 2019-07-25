using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    float speed = 15;

    float timer = 0f;
    float lifetime = 5f;

    void Start()
    {
        transform.SetParent(GameObject.Find("Canvas").transform);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
            Destroy(gameObject);
        
        transform.localScale = Vector3.one;
    }

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0 && Time.timeScale != 0)
        {
            transform.LookAt(GameObject.Find("Player").transform);
            transform.Translate(transform.forward * speed);
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().buildIndex.ToString());
            SceneManager.LoadScene("Lose");
            GameControlScript.gameOver = true;
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
