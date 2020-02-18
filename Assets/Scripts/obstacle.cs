using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D car)
    {
        // if (car.tag == "My Car")
        // {
            car.transform.Translate(new Vector3(Random.Range(-5.0f, 5.0f), 0, 0) * speed * Time.deltaTime);
            Debug.Log("Oil touched!");
        // }
    }

    // void OnTriggerStay2D(Collider2D car)
    // {
    //     if (car.tag == "My Car")
    //     {
    //         // -1 left - down | 1 right - front
    //         //car.transform.Translate(new Vector3(Random.Range(-1,1), Random.Range(-1,1), 0) * speed * Time.deltaTime);
    //         car.transform.Translate(new Vector3(Random.Range(-1.0f, 1.0f), 0, 0) * Random.Range(10.0f, 20.0f) * Time.deltaTime);
    //         //Debug.Log(car);
    //         Debug.Log("oil");
    //     }   
    // }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.tag == "My Car")
    //     {
    //         transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
    //         Debug.Log("Trigger Exit!");
    //     }
        
    // }
}
