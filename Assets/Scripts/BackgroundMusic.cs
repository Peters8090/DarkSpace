using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour {

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update ()
    {
        DontDestroyOnLoad(gameObject);

        if (PlayPause.paused && audioSource.isPlaying)
            audioSource.Pause();
        else if (!PlayPause.paused && !audioSource.isPlaying)
            audioSource.UnPause();
    }
}
