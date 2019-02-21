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
        transform.localPosition = new Vector2(Random.Range(-Screen.width / 2, Screen.width / 2), Random.Range(-Screen.height / 2, Screen.height / 2));
    }

    void Update()
    {

        timer += Time.deltaTime; 
        if (timer > 0.1f)
        {
            if (transform.localPosition.x < Screen.width / 2 && transform.localPosition.x > -(Screen.width / 2) && transform.localPosition.y < Screen.height / 2 && transform.localPosition.y > -(Screen.height / 2))
            {
                xMovement = Random.Range(-100, 100);
                yMovement = Random.Range(-100, 100);
                transform.Translate(xMovement, yMovement, 0);
            }

            else if (transform.localPosition.x < Screen.width / 2)
            {
                transform.Translate(50, 0, 0);
            }

            else if (transform.localPosition.x > -(Screen.width / 2))
            {
                transform.Translate(-50, 0, 0);
            }

            if (transform.localPosition.y > Screen.height / 2)
            {
                transform.Translate(0, -50, 0);
            }

            if (transform.localPosition.y < -(Screen.height / 2))
            {
                transform.Translate(0, 50, 0);
            }
            timer = 0;
        }
    }
}
