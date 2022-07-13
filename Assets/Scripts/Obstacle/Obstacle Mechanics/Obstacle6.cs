using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle6 : MonoBehaviour
{
    int moveSpeed = 4;

    void Update()
    {
        if (transform.position.y < 0.85)
        {
            moveSpeed = 4;
        }

        if (transform.position.y > 3.5)
        {
            moveSpeed = -4;
        }

        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

}
