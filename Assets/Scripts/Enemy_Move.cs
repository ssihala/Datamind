using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour {

    public int EnemySpeed;
    public float patrolDistance;
    public int XMoveDirection;
    public Animator animator;
    SpriteRenderer sprite;
    public static bool move = true;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (!move)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePosition;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0), patrolDistance);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
            animator.SetFloat("Horizontal", gameObject.GetComponent<Rigidbody>().velocity.x);
            animator.SetFloat("Speed", gameObject.GetComponent<Rigidbody>().velocity.sqrMagnitude);

            if (hit.collider != null && hit.collider.tag != "Player")
            {
                Flip();
                //if (hit.collider.tag == "Player") {
                //  Destroy(hit.collider.gameObject);
                //}
            }
            //PLAYER DIRECTION
            if (XMoveDirection < 0.0f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (XMoveDirection > 0.0f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    void Flip() {
        if (XMoveDirection > 0) {
            XMoveDirection = -1;
            sprite.flipX = true;
        } else {
            XMoveDirection = 1;
            sprite.flipX = false;
        }
    }
}
