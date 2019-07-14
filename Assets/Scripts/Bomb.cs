using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
    }
    void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime >= 0.65f)
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
    }
}
