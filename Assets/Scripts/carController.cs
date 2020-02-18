using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{

    public float carSpeed;
    Vector3 position;
    public uiManager ui;
    public audioManager am;

    bool currentPlatformAndroid = false;

    //max track position
    public float maxPosition = 2.2f;
    public float minPosition = -4.5f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //ui = GetComponent<uiManager>();
        //current / start car position
        position = transform.position;

        //Rigidbody
        rb = GetComponent<Rigidbody2D>();

        //check platform
        #if UNITY_ANDROID
                currentPlatformAndroid = true;
        #else
                currentPlatformAndroid = false;
        #endif

        if (currentPlatformAndroid == true)
        {
            Debug.Log("Android Platform");
        }
        else
        {
            Debug.Log("Windows Platform");
        }

        // start car sound
        am.carSound.Play();

    }

    // Update is called once per frame
    void Update()
    {

        if (currentPlatformAndroid == true)
        {
            //android specific code
            //TouchMove();
            AccelerometerMove();

        }
        else
        {
            //windows specific code
            //turn right or left car position
            position.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

            //limit track
            position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
            position.y = Mathf.Clamp(position.y, -4.5f, 4.5f);

            //new car position
            transform.position = position;
        }

        position = transform.position;

        //limit track
        position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);
        position.y = Mathf.Clamp(position.y, -4.5f, 4.5f);

        //new car position
        transform.position = position;

    }

    //on collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            //if collider with an enemy car, destroy my car.
            //Destroy(gameObject);
            gameObject.SetActive(false);
            //game over stop the score
            ui.gameOverActivated();
            // stop the car sound
            am.carSound.Stop();
        }
    }

    //touch controller
    // public void TouchMove()
    // {
    //     if (Input.touchCount > 0)
    //     {
    //         Touch touch = Input.GetTouch(0);

    //         float middle = Screen.width / 2;

    //         if (touch.position.x < middle && touch.phase == TouchPhase.Began)
    //         {
    //             //move left function
    //             MoveLeft();
    //         }
    //         else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
    //         {
    //             //move right function
    //             MoveRight();
    //         }
    //     }
    //     else
    //     {
    //         SetVelocityZero();
    //     }
    // }

    //android accelerometer
    public void AccelerometerMove()
    {
        //move left x right
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;

        //debug
        // Debug.Log("X = " + x + " Y = " +y);

        //left
        if (x < -0.1f)
        {
            MoveLeft();   
        }
        //right
        else if (x > 0.1f)
        {
            MoveRight();
        }
        else if (y < -0.1f)
        {
            moveDown();
        }
        else if (y > 0.1f)
        {
            moveUp();
        }

        else
        {
            SetVelocityZero();
        }

    }

    //android button controller
    public void MoveLeft()
    {
        //turn left
        rb.velocity = new Vector2(-carSpeed, 0);
    }

    public void MoveRight()
    {
        //turn right
        rb.velocity = new Vector2(carSpeed, 0);
    }

    public void moveUp()
    {
        rb.velocity = new Vector2(0, carSpeed);
    }

    public void moveDown()
    {
        rb.velocity = new Vector2(0, -carSpeed);
    }

    public void SetVelocityZero()
    {
        //stop the car
        rb.velocity = Vector2.zero;
    }

}