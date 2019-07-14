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

    public float touchX;
    public float touchY;

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
        speed = Screen.width / speedDivider;
        control = GameObject.Find("GameControlObject").GetComponent<GameControlScript>();
    }

    void Update()
    {
        if (Mathf.Abs(Input.acceleration.x) > 0 && Mathf.Abs(Input.acceleration.x) > 0.08f)
        {
            timer = 0;
            accelerationX = Input.acceleration.x * Time.deltaTime * Screen.width;
        }
        else
        {
            noMovement = true;
        }

        if (Mathf.Abs(Input.acceleration.y) > 0 && Mathf.Abs(Input.acceleration.y) > 0.08f)
        {
            timer = 0;
            noMovement = false;
            accelerationY = Input.acceleration.y * Time.deltaTime * Screen.width;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            accelerationX = -speed;
            accelerationY = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            accelerationX = speed;
            accelerationY = 0;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            accelerationY = speed;
            accelerationX = 0;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            accelerationY = -speed;
            accelerationX = 0;
        }
       
        if(noMovement)
        {
            timer += Time.deltaTime;
        }

        if(timer > 0.5f)
        {
            accelerationX = 0;
            accelerationY = 0;
        }

        if (accelerationX != 0 && accelerationY != 0)
        {
            transform.localEulerAngles = Vector3.zero;
        }

        if (transform.localPosition.x <= Screen.width / 2 && transform.localPosition.x >= -(Screen.width / 2) && transform.localPosition.y <= Screen.height / 2 && transform.localPosition.y >= -(Screen.height / 2))
        {
            transform.Translate(accelerationX, accelerationY, 0f);
            //transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(accelerationX + transform.localPosition.x, accelerationY + transform.localPosition.y, 0f), smoothSpeed);
        }

        else if (transform.localPosition.x < Screen.width / 2)
        {
            transform.Translate(1, 0, 0);
        }

        else if (transform.localPosition.x > -(Screen.width / 2))
        {
            transform.Translate(-1, 0, 0);
        }

        if (transform.localPosition.y > Screen.height / 2)
        {
            transform.Translate(0, -1, 0);
        }

        if (transform.localPosition.y < -(Screen.height / 2))
        {
            transform.Translate(0, 1, 0);
        }

        foreach (Touch touch in Input.touches)
        {
            touchX = touch.position.x;
            touchY = touch.position.y;

            touchPosition = new Vector2(touchX, touchY);

            // && GameObject.FindGameObjectsWithTag("Bomb").Length < 10
            if (touch.phase == TouchPhase.Began)
            {
                Instantiate(bomb, touchPosition, transform.rotation);
            }
        }
        
        if (accelerationX != 0 && accelerationY != 0)
        {
            //transform.Rotate(new Vector3(0, 0, Mathf.Atan2(accelerationY, accelerationX) * Mathf.Rad2Deg - 90));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(accelerationY, accelerationX) * Mathf.Rad2Deg - 90)), smoothSpeed);
        }

        touchX = Input.mousePosition.x;
        touchY = Input.mousePosition.y;

        touchPosition = new Vector2(touchX, touchY);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bomb, touchPosition, transform.rotation);
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