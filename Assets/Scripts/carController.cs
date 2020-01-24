using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{

    public float speed;
    Vector3 position;
    public uiManager ui;
    public audioManager am;

    //max track position
    public float maxPosition = 2.2f;

    // Start is called before the first frame update
    void Start()
    {
        //ui = GetComponent<uiManager>();
        //current / start car position
        position = transform.position;

        // start car sound
        am.carSound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
        //turn right or left car position
        position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //limit track
        position.x = Mathf.Clamp(position.x, -2.2f, 2.2f);

        //new car position
        transform.position = position;

    }

    //on collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            //if collider with an enemy car, destroy my car.
            Destroy(gameObject);
            //game over stop the score
            ui.gameOverActivated();
            // stop the car sound
            am.carSound.Stop();
        }
    }
}
