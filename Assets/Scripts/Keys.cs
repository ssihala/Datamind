using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public static int playerKeys;
    GameObject k1, k2, k3, k4, k5, k6;

    public static void gainKey()
    {
        playerKeys++;  
    }


    // Start is called before the first frame update
    void Start()
    {
        playerKeys = 0;
        k1 = GameObject.Find("Key1");
        k2 = GameObject.Find("Key2");
        k3 = GameObject.Find("Key3");
        k4 = GameObject.Find("Key4");
        k5 = GameObject.Find("Key5");
        k6 = GameObject.Find("Key6");

        k1.SetActive(false);
        k2.SetActive(false);
        k3.SetActive(false);
        k4.SetActive(false);
        k5.SetActive(false);
        k6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerKeys);
        switch (playerKeys)
        {
            case 1:
                k1.SetActive(true);
                break;
            case 2:
                k2.SetActive(true);
                break;
            case 3:
                k3.SetActive(true);
                break;
            case 4:
                k4.SetActive(true);
                break;
            case 5:
                k5.SetActive(true);
                break;
            case 6:
                k6.SetActive(true);
                break;
        }
    }
}
