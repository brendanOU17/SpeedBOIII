using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateItem : MonoBehaviour
{
    public float x,y,z;
    void Update()
    {
        transform.Rotate(x* Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }
}
