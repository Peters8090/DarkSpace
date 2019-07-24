using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float timer = 1;
    public float timer2 = 0;
    private float xMovement;
    private float yMovement;
    public GameObject bullet;

	void Start () {
        transform.localPosition = new Vector2(Random.Range(-Display.main.systemWidth / 2, Display.main.systemWidth / 2), Random.Range(-Display.main.systemHeight / 2, Display.main.systemHeight / 2));
    }
	
	void FixedUpdate () {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer > 0.01f && Time.timeScale != 0)
        {
            if (transform.localPosition.x < Display.main.systemWidth / 2 && transform.localPosition.x > -(Display.main.systemWidth / 2) && transform.localPosition.y < Display.main.systemHeight / 2 && transform.localPosition.y > -(Display.main.systemHeight / 2))
            {
                xMovement = Random.Range(-20, 20);
                yMovement = Random.Range(-20, 20);
                transform.Translate(xMovement, yMovement, 0);
            }

            else if (transform.localPosition.x < Display.main.systemWidth / 2)
            {
                transform.Translate(50, 0, 0);
            }

            else if (transform.localPosition.x > -(Display.main.systemWidth / 2))
            {
                transform.Translate(-50, 0, 0);
            }

            if (transform.localPosition.y > Display.main.systemHeight / 2)
            {
                transform.Translate(0, -50, 0);
            }

            if (transform.localPosition.y < -(Display.main.systemHeight / 2))
            {
                transform.Translate(0, 50, 0);
            }
            timer = 0;
        }

        if(timer2 > 3)
        {
            GameObject.Find("EnemyShootSound").GetComponent<AudioSource>().Play();
            Instantiate(bullet, transform.position, transform.rotation);
            timer2 = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "NoTouchArea")
            transform.localPosition = new Vector2(Random.Range(-Display.main.systemWidth / 2, Display.main.systemWidth / 2), Random.Range(-Display.main.systemHeight / 2, Display.main.systemHeight / 2));
    }
}
