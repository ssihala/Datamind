using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedPlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    public static float defaultSpeed = 1f;
    float moveLimiter = 0.7f;
    public Animator animator;
    public static float runSpeed = 1f;
    Vector2 movement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        WaitForSecondsRealtime test = new WaitForSecondsRealtime(1);
        movement.x = Input.GetAxisRaw("Horizontal"); // -1 is left
        movement.y = Input.GetAxisRaw("Vertical"); // -1 is down

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
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
        if (movement.x != 0 && movement.y != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }

        body.MovePosition(body.position + movement * runSpeed * Time.fixedDeltaTime);
    }
}
