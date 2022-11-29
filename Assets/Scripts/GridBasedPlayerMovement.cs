using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedPlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public static float defaultSpeed = 1f;
    public Animator animator;

    public static float runSpeed = 1f;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        WaitForSecondsRealtime test = new WaitForSecondsRealtime(1);
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
    }

    public static void toggleMovement()
    {
        if (runSpeed != 0)
            runSpeed = 0;
        else
            runSpeed = defaultSpeed;
    }


    void FixedUpdate()
    {
        /*if(horizontal == 1)
        {
            body.position = new Vector2(body.position.x + 0.16f, body.position.y);
        }
        else if(horizontal == -1)
        {
            body.position = new Vector2(body.position.x - 0.16f, body.position.y);
        }
        if(vertical == 1)
        {
            body.position = new Vector2(body.position.x, body.position.y + 0.16f);
        }
        else if(vertical == -1)
        {
            body.position = new Vector2(body.position.x, body.position.y - 0.16f);
        }*/
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
