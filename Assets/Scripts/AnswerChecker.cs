using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// This script serves to validate user input for user answers
// Aka if the question is 2 + 2, check for the correct answer
public class AnswerChecker : MonoBehaviour
{
    public int expectedAnswer;
    public GameObject input;
    void checkInput()
    {
        string ans = input.GetComponent<TMP_InputField>().text;
        if (ans == expectedAnswer.ToString())
        {
            // Answer is correct, do something based on the answer being right
            Debug.Log("TEXT IS EQUAL");
        }
        else
        {
            // Answer is wrong, do something based on the answer being wrong
            Debug.Log(ans);
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
        if(Input.GetKeyDown(KeyCode.Return))
        {
            checkInput();
        }
    }
}