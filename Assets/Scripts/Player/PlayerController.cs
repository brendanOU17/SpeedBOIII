using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float yMovement = Input.GetAxis("Vertical") * movementSpeed / 2;

        transform.Translate(new Vector3(xMovement, 0, yMovement) * Time.deltaTime);
    }
}
