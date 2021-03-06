using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public Text scoreText;
    public float highscore;
    public static int score;
    [SerializeField] private SoundData playerSFX;
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
            if (/*Input.GetKeyDown(KeyCode.Space)||*/ SwipeManager.swipeUp)
            {
                Jump();
            }
        }

        if (/*Input.GetKeyDown(KeyCode.D)||*/ SwipeManager.swipeRight)
        {
            lanes++;
            if(lanes == 3)
                lanes = 2;
        }

        if (/*Input.GetKeyDown(KeyCode.A)||*/ SwipeManager.swipeLeft)
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

        //transform.position = Vector3.Lerp(transform.position,targetPosition, 70 * Time.deltaTime); 

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            Controller.Move(moveDir);
        else
            Controller.Move(diff);

        
    }

    private void FixedUpdate()
    {
        Controller.Move(direction*Time.deltaTime);
        score = (int)transform.position.z;
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == ("Obstacle"))
        {
            PlayerManager.gameOver = true;
            SoundManager.instance.PlaySFX(playerSFX, "PlayerDie");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        spawnManager.SpawnTriggerEntered();
    }
}
