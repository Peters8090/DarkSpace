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


    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        speed = Screen.width / speedDivider;
        control = GameObject.Find("GameControlObject").GetComponent<GameControlScript>();
    }

    void Update()
    {
        if (Mathf.Abs(Input.acceleration.x) > 0 && Mathf.Abs(Input.acceleration.x) < 0.6f)
        {
            accelerationX = Input.acceleration.x * Time.deltaTime * Screen.width;
        }

        if (Mathf.Abs(Input.acceleration.y) > 0 && Mathf.Abs(Input.acceleration.y) < 0.6f)
        {
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


        transform.eulerAngles = new Vector3(0, 0);

        if (transform.localPosition.x <= Screen.width / 2 && transform.localPosition.x >= -(Screen.width / 2) && transform.localPosition.y <= Screen.height / 2 && transform.localPosition.y >= -(Screen.height / 2))
        {
            transform.Translate(accelerationX, accelerationY, 0f);
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

            if (touch.phase == TouchPhase.Began)
            {
                Instantiate(bomb, touchPosition, transform.rotation);
            }
        }


        touchX = Input.mousePosition.x;
        touchY = Input.mousePosition.y;

        touchPosition = new Vector2(touchX, touchY);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bomb, touchPosition, transform.rotation);
        }

        transform.Rotate(0, 0, Mathf.Atan2(accelerationY, accelerationX) * Mathf.Rad2Deg - 90);
        
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
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