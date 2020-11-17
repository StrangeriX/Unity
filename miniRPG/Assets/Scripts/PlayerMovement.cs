using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    Vector3 velocity;
    public Transform groundCheck;

    public float walkspeed = 7f;
    public float runspeed = 12f;
    private float speed;
    private float gravity = -9f;
    private float groundDistance = 0.4f;
    public float jumpHeight = 1f;
    public LayerMask groundMask;
    bool isGrounded;
    private bool isMoving = false;

    private AudioSource audioS;


    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        speed = walkspeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runspeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkspeed;
        }

        if (x != 0 || z !=0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


    }

    private void FixedUpdate()
    {
        FootStepSound();
    }

    public void FootStepSound()
    {
        if (isMoving)
        {
            audioS.enabled = true;
            audioS.loop = true;
        }
        if(!isMoving || !isGrounded)
        {
            audioS.enabled = false;
            audioS.loop = false;
        }

    }

}
