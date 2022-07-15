using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float rotate;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime,0, rotate * Time.deltaTime);
    }
}
