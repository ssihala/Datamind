using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    public static Dictionary<string, int> questions = new Dictionary<string, int>();
    public static bool randomize = true;
    public static int randomIndex = 0;
    public bool init = true;
    // 1 = addition, 2 = subtraction, 3 = both, 4 = multiplication, 5 = all three?
    public int difficulty = 1;
    char operand = ' ';
    char operand2 = ' ';
    char operand3 = ' ';
    int maxVal = 0;
    int answer = 0;
    string currExpression = " ";
    // Start is called before the first frame update

    void initializeQuestions()
    {
        switch(difficulty)
        {
            case 1:
                operand = '+';
                maxVal = 15;
                break;
            case 2:
                operand = '-';
                maxVal = 15;
                break;
            case 3:
                operand = '+';
                operand2 = '-';
                maxVal = 50;
                break;
            case 4:
                operand = '*';
                maxVal = 12;
                break;
            case 5:
                operand = '+';
                operand2 = '-';
                operand3 = '*';
                maxVal = 12;
                break;
            default:
                // Error message bc difficulty is not set
                break;
        }
        for(int i = 1; i <= maxVal; i++)
        {
            for(int j = 1; j <= maxVal; j++)
            {
                currExpression = i.ToString();
                string op = " + ";
                currExpression += op;
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
                currExpression = "";
            }
        }
        return;
    }
    void Start()
    {
        initializeQuestions();
    }

    // Update is called once per frame
    void Update()
    {
        if(randomize)
        {
            randomIndex = Random.Range(0, questions.Count);
            Debug.Log(randomIndex);
            randomize = false;
        }
        
    }
}
