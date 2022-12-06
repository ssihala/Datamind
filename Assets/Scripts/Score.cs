using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int playerScore = 0;

    //SCORE NEEDS TO BE READ IN FROM THE PLAYER'S SAVE FILE ON LOAD AND NEED TO BE WRITTEN BACK TO THE FILE ON SAVE
    void Start()
    {
        if(LoginWrite.currUser[3] == null)
        {
            playerScore = 0;
        }
        else
        {
            Int32.TryParse(LoginWrite.currUser[3], out playerScore);
        }
    }

    public static void increaseScore(int num)
    {
        playerScore += num;
        LoginWrite.currUser[3] = Convert.ToString(playerScore);
    }

    public static void decreaseScore(int num)
    {
        playerScore -= num;
        LoginWrite.currUser[3] = Convert.ToString(playerScore);
    }
}
