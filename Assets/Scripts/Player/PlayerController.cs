using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public SpawnManager spawnManager;
    private CharacterController Controller;
    private Vector3 direction;
    public float zMoveSpeed;
    private int lanes = 1;
    public float laneDistance;
    public float jumpForce;
    public float gravity = -20;
    void Start()
    {
    Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = zMoveSpeed;

        direction.y += gravity* Time.deltaTime;
        if (Controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            lanes++;
            if(lanes == 3)
                lanes = 2;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            lanes--;
            if (lanes == -1)
                lanes = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lanes == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (lanes == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = targetPosition; //Vector3.Lerp(transform.position,targetPosition, 20 * Time.deltaTime); 
    }

    private void FixedUpdate()
    {
        Controller.Move(direction*Time.deltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
}
