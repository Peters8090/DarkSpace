using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    /// <summary>
    /// Max speed of enemy
    /// </summary>
    float maxSpeed = 1000f;

    /// <summary>
    /// The higher it is, the move is more chaotic
    /// </summary>
    float moveDirChangeInterval = 0.1f;
    float checkPositionInterval = 1f;
    float shootingInterval = 3f;

    //current movement speeds
    float movementX;
    float movementY;

    public GameObject bullet;
    Rigidbody2D rb;
    AudioSource enemyShootingSound;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        enemyShootingSound = GameObject.Find("EnemyShootSound").GetComponent<AudioSource>();

        //start position is random
        RandomizePosition();

        InvokeRepeating("Move", 0, moveDirChangeInterval);

        InvokeRepeating("CheckPosition", 0, checkPositionInterval);

        //there are 2 types of enemies, only Enemy1 can shoot
        if(gameObject.name == "Enemy1")
            InvokeRepeating("Shoot", shootingInterval, shootingInterval);
    }
    
    void Move()
    {
        movementX = Random.Range(-maxSpeed, maxSpeed);
        movementY = Random.Range(-maxSpeed, maxSpeed);

        rb.velocity = new Vector2(movementX, movementY);
    }

    void LateUpdate()
    {
        transform.localEulerAngles = Vector3.zero;
    }

    /// <summary>
    /// Prevents flying out of the screen
    /// </summary>
    void CheckPosition()
    {
        if (transform.localPosition.x > Display.main.systemWidth / 2 || //right
            transform.localPosition.x < -(Display.main.systemWidth / 2) || //left
            transform.localPosition.y > Display.main.systemHeight / 2 || //top
            transform.localPosition.y < -(Display.main.systemHeight / 2)) //bottom
        {
            RandomizePosition();
        }
    }

    void RandomizePosition()
    {
        transform.localPosition = new Vector2(Random.Range(-Display.main.systemWidth / 2, Display.main.systemWidth / 2), Random.Range(-Display.main.systemHeight / 2, Display.main.systemHeight / 2));
    }

    void Shoot()
    {
        enemyShootingSound.Play();
        Instantiate(bullet, transform.position, transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "NoTouchArea" || coll.gameObject.tag == "Player")
            RandomizePosition();
    }
}
