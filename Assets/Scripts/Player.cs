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
    
    public float accelerationX;
    public float accelerationY;

    /// <summary>
    /// When it gets lower, the player speed gets higher
    /// </summary>
    float speedDivider = 400;

    float speed = 12;

    float timer = 0;

    Vector3 targetRot = Vector3.zero;

    float smoothSpeed = 5f;

    bool noMovement = false;
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        speed = Display.main.systemWidth / speedDivider;
        control = GameObject.Find("GameControlObject").GetComponent<GameControlScript>();
    }

    void Update()
    {
        if (Mathf.Abs(Accelerometer.x) > 0 && Mathf.Abs(Accelerometer.x) > 0.08f)
        {
            timer = 0;
            accelerationX = Accelerometer.x * Time.deltaTime * Display.main.systemWidth;
        }
        else
        {
            noMovement = true;
        }

        if (Mathf.Abs(Accelerometer.y) > 0 && Mathf.Abs(Accelerometer.y) > 0.08f)
        {
            timer = 0;
            noMovement = false;
            accelerationY = Accelerometer.y * Time.deltaTime * Display.main.systemWidth;
        }
        
        if(noMovement)
        {
            timer += Time.deltaTime;
        }

        if(timer > 0.5f || Time.timeScale == 0)
        {
            accelerationX = 0;
            accelerationY = 0;
        }

        if (accelerationX != 0 && accelerationY != 0)
        {
            transform.localEulerAngles = Vector3.zero;
        }

        if (transform.localPosition.x <= Display.main.systemWidth / 2 && transform.localPosition.x >= -(Display.main.systemWidth / 2) && transform.localPosition.y <= Display.main.systemHeight / 2 && transform.localPosition.y >= -(Display.main.systemHeight / 2))
        {
            transform.Translate(accelerationX, accelerationY, 0f);
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
        
        foreach (Touch touch in Input.touches)
        {
            touchPosition = new Vector2(touch.position.x, touch.position.y);

            if (PlayPause.paused)
                return;

            if (touch.phase == TouchPhase.Began)
            {
                Instantiate(bomb, touchPosition, transform.rotation);
            }
        }

        if (Input.GetButtonDown("Fire1") && Application.platform != RuntimePlatform.Android)
        {
            Instantiate(bomb, new Vector2(Input.mousePosition.x, Input.mousePosition.y), transform.rotation);
        }

        if (accelerationX != 0 && accelerationY != 0)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(accelerationY, accelerationX) * Mathf.Rad2Deg - 90)), smoothSpeed);
        }


        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            if(SceneManager.GetActiveScene().buildIndex < 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                control.gameOver = true;
                SceneManager.LoadScene(4);
            }

        }
    }
}