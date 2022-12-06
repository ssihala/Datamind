using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// This script serves to validate user input for user answers
// Aka if the question is 2 + 2, check for the correct answer
public class AnswerChecker : MonoBehaviour
{
    public int expectedAnswer = 0;
    public int playerHealth = Health.playerHealth;
    public static int enemyScore;
    private bool check = false;
    public GameObject input;
    public GameObject enemy;
    public static int numAttempted = 0;
    public static int numCorrect = 0;

    public static void setEnemyScore(int value)
    {
        enemyScore = value;
    }

    void checkInput()
    {
        numAttempted++;
        string ans = input.GetComponent<TMP_InputField>().text;
        expectedAnswer = QuestionGenerator.questions.ElementAt(QuestionGenerator.randomIndex).Value;
        if (ans == expectedAnswer.ToString())
        {
            // Answer is correct, do something based on the answer being right
            DialogueBox.erase = true;
            DialogueBox.display = false;
            Destroy(enemy);
            GridBasedPlayerMovement.toggleMovement();
            QuestionGenerator.randomize = true;
            Enemy_Move.move = true;
            input.GetComponent<TMP_InputField>().text = "";
            //ADD KEY
            Keys.gainKey();
            //INCREASE SCORE
            Score.increaseScore(enemyScore);
            numCorrect++;
        }
        else
        {
            // Answer is wrong, do something based on the answer being wrong
            
            Health.playerDamage();
            //DECREASE SCORE
            Score.decreaseScore(enemyScore);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Only check if the answer is correct when return is pressed
        if (Input.GetKeyDown(KeyCode.Return) && check)
        {
            checkInput();
            //this.check = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    // Only run the script on the enemy when the player enters its trigger
    {
        this.check = true;
    }
}
