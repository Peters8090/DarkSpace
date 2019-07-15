using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPause : MonoBehaviour
{
    [SerializeField]
    Texture playTexture;
    [SerializeField]
    Texture pauseTexture;

    RawImage rawImage;

    public static bool paused = false;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        if (paused)
        {
            Time.timeScale = 0f;

            rawImage.texture = playTexture;
        }
        else
        {
            Time.timeScale = 1f;
            rawImage.texture = pauseTexture;
        }
        transform.SetAsLastSibling();
    }

    void OnClick()
    {
        Accelerometer.Calibrate();
        paused = !paused;
    }
}
