using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public static float calibAccX = 0; //X acceleration on calibration
    public static float calibAccY = 0; //Y acceleration on calibration

    /// <summary>
    /// Calibrated accelerometer X input
    /// </summary>
    public static float x ;

    /// <summary>
    /// Calibrated accelerometer Y input
    /// </summary>
    public static float y;

    void Start()
    {
        Calibrate();
    }

    public static void Calibrate ()
    {
        calibAccX = Input.acceleration.x;
        calibAccY = Input.acceleration.y;
    }
    
    void Update()
    {
        x = Input.acceleration.x - calibAccX;
        y = Input.acceleration.y - calibAccY;
    }
}
