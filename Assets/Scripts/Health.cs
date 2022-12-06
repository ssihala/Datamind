using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static int playerHealth;
    GameObject h3, h2, h1;

    public static void playerDamage()
    {
        playerHealth--;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
        h3 = GameObject.Find("Heart3");
        h2 = GameObject.Find("Heart2");
        h1 = GameObject.Find("Heart1");

        h3.SetActive(true);
        h2.SetActive(true);
        h1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == 2)
        {
            //REMOVE HEART 3
            h3.SetActive(false);
        }
        if (playerHealth == 1)
        {
            //REMOVE HEART 2
            h2.SetActive(false);

        }
        if (playerHealth == 0)
        {
            h1.SetActive(false);
            SceneManager.LoadScene(6);
            //DEATH
        }
    }
}

