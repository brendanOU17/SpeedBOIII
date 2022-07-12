using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle4 : MonoBehaviour
{
    int moveSpeed= 4;

     void Update()
    {
        if(transform.position.x < -2)
        {
            moveSpeed = 4;
        }

        if (transform.position.x > 2)
        {
            moveSpeed = -4;
        }

        transform.Translate(moveSpeed*Time.deltaTime,0,0);
    }

}
