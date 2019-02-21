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
        transform.localPosition = new Vector2(Random.Range(-Screen.width / 2, Screen.width / 2), Random.Range(-Screen.height / 2, Screen.height / 2));
        
    }
	
	void Update () {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer > 0.01f)
        {
            if (transform.localPosition.x < Screen.width / 2 && transform.localPosition.x > -(Screen.width / 2) && transform.localPosition.y < Screen.height / 2 && transform.localPosition.y > -(Screen.height / 2))
            {
                xMovement = Random.Range(-20, 20);
                yMovement = Random.Range(-20, 20);
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

        if(timer2 > 3)
        {
            GameObject.Find("EnemyShootSound").GetComponent<AudioSource>().Play();
            Instantiate(bullet, transform.position, transform.rotation);
            timer2 = 0;
        }
    }
}
