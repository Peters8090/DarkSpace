using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer;

    void Start()
    {
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.65f)
        {
            Destroy(gameObject);
        }

        transform.localScale = Vector3.one;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Bullet")
        {
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.tag == "NoTouchArea")
            Destroy(gameObject);
    }
}
