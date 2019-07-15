using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject bgMusicObj;

    void Start()
    {
        //instantiate the bgMusicObj at the beginning of the game
        if (Time.time == 0)
            Instantiate(bgMusicObj);
    }
}
