using UnityEngine;
using System.Collections;


public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    
    void Awake()
    {
        currentHealth = startingHealth;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("getting collision");
        if (col.gameObject.tag == "Bullet")
        {
            currentHealth = currentHealth - 10;
            //Debug.Log("killing stuff");
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject, 2f);
        }
    }

}

