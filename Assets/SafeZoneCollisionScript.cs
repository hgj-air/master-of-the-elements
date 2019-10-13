using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneCollisionScript : MonoBehaviour
{
    private int counter = 0;
    void Start()
    {
    }
    
    void Update()
    {
        float xpos = transform.position.x;
        float zpos = transform.position.z;
        if(xpos > -1.5 && xpos < 1.5 && zpos > -1.5 && zpos < 1.5)
        {
            if (--StateManager.Instance.Lives <= 0)
            {
                Debug.Log("Game over!");
            }

            StateManager.Instance.Score -= 1000;

            Destroy(gameObject);
        }
    }
}