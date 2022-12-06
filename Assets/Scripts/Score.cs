using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int playerScore;

    //SCORE NEEDS TO BE READ IN FROM THE PLAYER'S SAVE FILE ON LOAD AND NEED TO BE WRITTEN BACK TO THE FILE ON SAVE
    void Start()
    {
        
    }

    public static void increaseScore(int num)
    {
        playerScore += num;
    }

    public static void decreaseScore(int num)
    {
        playerScore -= num;
    }
}
