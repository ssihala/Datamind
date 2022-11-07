using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        Collider2D playerCol = player.GetComponent<Collider2D>();
        Collider2D thisCol = this.GetComponent<Collider2D>();
        if(playerCol.IsTouching(thisCol))
        {
            Debug.Log("TOUCHING");
        }

        /*GameObject player = GameObject.Find("Player");
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        float distance = directionToPlayer.magnitude;
        if (Mathf.Abs(angle) == 90 && distance < 150)
        {
            Debug.Log("IN FRONT OF ME");
        }
        */

    }
}