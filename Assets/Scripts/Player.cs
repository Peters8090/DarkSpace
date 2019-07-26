using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bomb;
    
    /// <summary>
    /// Current X movement speed
    /// </summary>
    float movementX;

    /// <summary>
    /// Current Y movement speed
    /// </summary>
    float movementY;

    float speed = 20;
    
    FixedJoystick joystick;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        joystick = FindObjectOfType<FixedJoystick>();
    }

    void Update()
    {
        //only one touch can be detected in one frame, it makes the game more difficult
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
        {
            Instantiate(bomb, new Vector2(Input.mousePosition.x, Input.mousePosition.y), transform.rotation);
        }

        //if there are no enemies
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            if (SceneManager.GetActiveScene().buildIndex < 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                GameControlScript.gameOver = true;
                SceneManager.LoadScene(4);
            }
        }
    }

    void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            movementX = joystick.Horizontal * speed;
            movementY = joystick.Vertical * speed;
        }
        //reset rotation before transform.Translate
        if (movementX != 0 && movementY != 0)
        {
            transform.localEulerAngles = Vector3.zero;
        }

        if(Time.timeScale != 0)
        {
            if (transform.localPosition.x < Display.main.systemWidth / 2 && //right
                transform.localPosition.x > -(Display.main.systemWidth / 2) && //left
                transform.localPosition.y < Display.main.systemHeight / 2 &&  //top
                transform.localPosition.y > -(Display.main.systemHeight / 2)) //bottom
            {
                transform.Translate(movementX, movementY, 0f);
            }

            //player cannot fly out of the screen
            else if (transform.localPosition.x < Display.main.systemWidth / 2)
            {
                transform.Translate(1, 0, 0);
            }

            else if (transform.localPosition.x > -(Display.main.systemWidth / 2))
            {
                transform.Translate(-1, 0, 0);
            }

            if (transform.localPosition.y > Display.main.systemHeight / 2)
            {
                transform.Translate(0, -1, 0);
            }

            if (transform.localPosition.y < -(Display.main.systemHeight / 2))
            {
                transform.Translate(0, 1, 0);
            }
        }

        if (movementX != 0 && movementY != 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(movementY, movementX) * Mathf.Rad2Deg - 90);
        }
    }
}