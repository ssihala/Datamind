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

<<<<<<< Updated upstream
    public float runSpeed = 20.0f;

=======
    public static float runSpeed = 1f;
>>>>>>> Stashed changes
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

<<<<<<< Updated upstream
=======
    public static void toggleMovement()
    {
        if (runSpeed != 0)
            runSpeed = 0;
        else
            runSpeed = defaultSpeed;
    }


>>>>>>> Stashed changes
    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
