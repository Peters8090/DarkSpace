using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    //current movement speeds
    float movementX;
    float movementY;

    float speed = 30f;

    public GameObject bullet;

    /// <summary>
    /// Equal to true when gameObject visible on the screen
    /// </summary>
    bool onScreen = false;

	void Start () {
        //start position is random
        RandomizePosition();

        //there are 2 types of enemies, only Enemy1 can shoot
        if(gameObject.name == "Enemy1")
            InvokeRepeating("Shoot", 3, 3);
    }
    
    void FixedUpdate()
    {
        transform.localEulerAngles = Vector3.zero;

        //to prevent flying out of the screen
        if (transform.localPosition.x < Display.main.systemWidth / 2) //right
        {
            transform.Translate(speed * 10, 0, 0);
        }
        if (transform.localPosition.x > -(Display.main.systemWidth / 2)) //left
        {
            transform.Translate(-speed * 10, 0, 0);
        }
        if (transform.localPosition.y > Display.main.systemHeight / 2) //top
        {
            transform.Translate(0, -speed * 10, 0);
        }
        if (transform.localPosition.y < -(Display.main.systemHeight / 2)) //bottom
        {
            transform.Translate(0, speed * 10, 0);
        }

        movementX = Random.Range(-speed, speed);
        movementY = Random.Range(-speed, speed);

        transform.Translate(movementX, movementY, 0);
    }

    void RandomizePosition()
    {
        transform.localPosition = new Vector2(Random.Range(-Display.main.systemWidth / 2, Display.main.systemWidth / 2), Random.Range(-Display.main.systemHeight / 2, Display.main.systemHeight / 2));
    }

    void Shoot()
    {
        GameObject.Find("EnemyShootSound").GetComponent<AudioSource>().Play();
        Instantiate(bullet, transform.position, transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "NoTouchArea")
            RandomizePosition();
    }
}
