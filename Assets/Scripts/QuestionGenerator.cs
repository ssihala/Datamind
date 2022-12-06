using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestionGenerator : MonoBehaviour
{
    public static Dictionary<string, int> questions = new Dictionary<string, int>();
    public static bool randomize = true;
    public static int randomIndex = 0;
    public bool init = true;
    // 1 = addition, 2 = subtraction, 3 = both, 4 = multiplication, 5 = all three?
    public static int difficulty = 1;
    // default level is level 1
    char operand = ' ';
    char operand2 = ' ';
    char operand3 = ' ';
    int maxVal = 0;
    int maxVal2 = 0;
    int answer = 0;
    string currExpression = " ";
    // Start is called before the first frame update

    void initializeQuestions()
    {
        string[] playerData = LoginWrite.currUser;
        if(playerData == null)
        {
            difficulty = 1;
        }
        else
        {
            Int32.TryParse(playerData[6], out difficulty);
            Debug.Log(difficulty);
        }
        // USERID,PASSWORD,LEVEL,ACCURACY,HEALTH,TIME,DIFFICULTY
        switch (difficulty)
        {
            // setting 1: Only Addition
            case 1:
                operand = '+';
                maxVal = 15;
                break;
            case 2:
            // setting 2: Only Subtraction
                operand = '-';
                maxVal = 15;
                break;
            case 3:
            // setting 3: Addition and Subtraction
                operand = '+';
                operand2 = '-';
                maxVal = 50;
                break;
            case 4:
            // setting 4: Multiplication
                operand = '*';
                maxVal = 12;
                break;
            case 5:
            // setting 5: All three (go crazy go stupid aaaahhh)
                operand = '+';
                operand2 = '-';
                operand3 = '*';
                // need to set a second maxVal to account for mult.
                maxVal = 50;
                maxVal2 = 12;
                break;
            default:
                // Error message bc difficulty is not set
                break;
        }
        // makes the questions w min/max values
        for(int i = 1; i <= maxVal; i++)
        {
            for(int j = 1; j <= maxVal; j++)
            {
                currExpression = i.ToString();
                currExpression += ' ';
                currExpression += operand;
                currExpression += ' ';
                currExpression += j.ToString();
                switch (operand)
                {
                    case '+':
                        answer = i + j;
                        break;
                    case '-':
                        answer = i - j;
                        break;
                    case '*':
                        answer = i * j;
                        break;

                }
                // non-negative questions only
                if(answer >= 0)
                {
                    questions.Add(currExpression, answer);
                }
                if(operand2 != ' ')
                {
                    currExpression = i.ToString();
                    currExpression += ' ';
                    currExpression += operand2;
                    currExpression += ' ';
                    currExpression += j.ToString();
                    switch (operand2)
                    {
                        case '+':
                            answer = i + j;
                            break;
                        case '-':
                            answer = i - j;
                            break;
                        case '*':
                            answer = i * j;
                            break;

                    }
                    // non-negative questions only
                    if (answer >= 0)
                    {
                        questions.Add(currExpression, answer);
                    }
                }
                currExpression = "";
            }
        }
        if (operand3 != ' ')
        {
            for (int i = 1; i < maxVal2; i++)
            {
                for (int j = 1; j <= maxVal2; j++)
                {

                    currExpression = i.ToString();
                    currExpression += ' ';
                    currExpression += operand3;
                    currExpression += ' ';
                    currExpression += j.ToString();
                    switch (operand3)
                    {
                        case '+':
                            answer = i + j;
                            break;
                        case '-':
                            answer = i - j;
                            break;
                        case '*':
                            answer = i * j;
                            break;
                    }
                    // non-negative questions only
                    if (answer >= 0)
                    {
                        questions.Add(currExpression, answer);
                    }
                }
                currExpression = "";
            }
        }
        return;
    }
    void Start()
    { 
        initializeQuestions();
        // if we need to get a random question...
        if (randomize)
        {
            randomIndex = UnityEngine.Random.Range(0, questions.Count);
            Debug.Log(randomIndex);
            randomize = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if we need to get a random question...
        if (randomize)
        {
            randomIndex = UnityEngine.Random.Range(0, questions.Count);
            Debug.Log(randomIndex);
            randomize = false;
        }
        }
        
    }
