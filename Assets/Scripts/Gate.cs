using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator animator;
    public static bool gateOpen;
    public static GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        gateOpen = false;
        portal = GameObject.Find("Portal");
        portal.SetActive(false);
        
    }

   public static void openGate()
    {
        gateOpen = true;
        portal.SetActive(true);
    }

    void Update()
    {
        animator.SetBool("gateOpen", gateOpen);
    }
}
