using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public GameObject win;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }

    void Update()
    {

    }
}
