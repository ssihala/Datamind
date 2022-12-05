using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float runTime;
    bool timerStarted;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(timerStarted)
            runTime += Time.deltaTime;
    }

    void startTimer()
    {
        runTime = 0;
        timerStarted = true;
    }
    void stopTimer()
    {
        timerStarted = false;
    }
}
