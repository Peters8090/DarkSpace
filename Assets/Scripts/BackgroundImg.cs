using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImg : MonoBehaviour
{
    float rotation = 5;
    
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotation * Time.timeScale));
    }
}
