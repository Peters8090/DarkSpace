using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject bomb;

    public Vector2 touchPosition;
    public Vector2 dir = Vector2.zero;

    private GameControlScript control;
    
    public float movementX;
    public float movementY;

    /// <summary>
    /// When it gets lower, the player speed gets higher
    /// </summary>
    float speedDivider = 200;

    float speed = 12;
    
    FixedJoystick joystick;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        speed = Display.main.systemWidth / speedDivider;
        joystick = FindObjectOfType<FixedJoystick>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            movementX = joystick.Horizontal * speed;
            movementY = joystick.Vertical * speed;
        }
        
        if (movementX != 0 && movementY != 0)
        {
            transform.localEulerAngles = Vector3.zero;
        }

        if(Time.timeScale != 0)
        {
            if (transform.localPosition.x <= Display.main.systemWidth / 2 && transform.localPosition.x >= -(Display.main.systemWidth / 2) && transform.localPosition.y <= Display.main.systemHeight / 2 && transform.localPosition.y >= -(Display.main.systemHeight / 2))
            {
                transform.Translate(movementX, movementY, 0f);
            }

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
        
        foreach (Touch touch in Input.touches)
        {
            touchPosition = new Vector2(touch.position.x, touch.position.y);

            if (PlayPause.paused)
                return;

            if (touch.phase == TouchPhase.Began && Time.timeScale != 0)
            {
                Instantiate(bomb, touchPosition, transform.rotation);
            }
        }

        if (Input.GetButtonDown("Fire1") && Application.platform != RuntimePlatform.Android && Time.timeScale != 0)
        {
            Instantiate(bomb, new Vector2(Input.mousePosition.x, Input.mousePosition.y), transform.rotation);
        }

        if (movementX != 0 && movementY != 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(movementY, movementX) * Mathf.Rad2Deg - 90);
        }


        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            if(SceneManager.GetActiveScene().buildIndex < 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                GameControlScript.gameOver = true;
                SceneManager.LoadScene(4);
            }

        }
    }
}