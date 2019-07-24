using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public float timer = 1;
    private float xMovement;
    private float yMovement;

    void Start()
    {
        transform.localPosition = new Vector2(Random.Range(-Display.main.systemWidth / 2, Display.main.systemWidth / 2), Random.Range(-Display.main.systemHeight / 2, Display.main.systemHeight / 2));
    }

    void FixedUpdate()
    {

        timer += Time.deltaTime; 
        if (timer > 0.1f && Time.timeScale != 0)
        {
            if (transform.localPosition.x < Display.main.systemWidth / 2 && transform.localPosition.x > -(Display.main.systemWidth / 2) && transform.localPosition.y < Display.main.systemHeight / 2 && transform.localPosition.y > -(Display.main.systemHeight / 2))
            {
                xMovement = Random.Range(-100, 100);
                yMovement = Random.Range(-100, 100);
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
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "NoTouchArea")
            transform.localPosition = new Vector2(Random.Range(-Display.main.systemWidth / 2, Display.main.systemWidth / 2), Random.Range(-Display.main.systemHeight / 2, Display.main.systemHeight / 2));
    }
}
