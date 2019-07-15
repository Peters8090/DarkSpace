using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImg : MonoBehaviour
{
    float rotation = 10;
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotation * Time.timeScale));
    }
}
