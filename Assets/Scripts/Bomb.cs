using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float lifetime;
    public float touchX;
    public float touchY;

    void Start()
    {
        
    }
    void Update()
    {
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform);

        lifetime += Time.deltaTime;
        if (lifetime >= 0.65f)
        {
            Destroy(gameObject);
        }
        foreach (Touch touch in Input.touches)
        {
            touchX = touch.position.x;
            touchY = touch.position.y;
        }



    }
}
