using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy" && gameObject.tag != "Enemy")
        {
            Destroy(coll.gameObject);
        }
    }
}