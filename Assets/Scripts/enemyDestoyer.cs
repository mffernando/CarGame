using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDestoyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Destroy the enemy car
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Car")
        {
            
            Destroy(col.gameObject);

        }
    }
}
