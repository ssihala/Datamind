using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator animator;
    public static bool gateOpen;

    // Start is called before the first frame update
    void Start()
    {
        gateOpen = false;
        
    }

   public static void openGate()
    {
        gateOpen = true;
    }

    void Update()
    {
        animator.SetBool("gateOpen", gateOpen);
    }
}
