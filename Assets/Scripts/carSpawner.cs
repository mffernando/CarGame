using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{

    //car object
    //public GameObject car;
    public GameObject[] cars;
    public int carID;

    //max car position
    public float maxPosition = 2.2f;

    //spawn cars time
    public float delayTimer = 1f;

    float timer;

    // Start is called before the first frame update
    void Start()
    {

        timer = delayTimer;
        
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {

        //random car position, min and max position
        Vector3 carPosition = new Vector3(Random.Range(-2.2f, 2.2f), 
                transform.position.y, transform.position.z);

        //random cars
        carID = Random.Range(0,3);

        //Instantiate(car, transform.position, transform.rotation);
        //instantiate cars by id, car 1, car 2 ...
        Instantiate(cars[carID], carPosition, transform.rotation);
        


        timer = delayTimer;

        }    
    }
}
