using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public int obstacleID;
    public float maxPosition = 2.2f;
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
            //random obstacle position, min and max position
            Vector3 obstaclePosition = new Vector3(Random.Range(-2.2f, 2.2f),
                    transform.position.y, transform.position.z);

            //random obstacles
            obstacleID = Random.Range(0, 1);

            Instantiate(obstacles[obstacleID], obstaclePosition, transform.rotation);

            timer = delayTimer;
        }

    }
}
