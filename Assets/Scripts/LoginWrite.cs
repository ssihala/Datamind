using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginWrite : MonoBehaviour
{
    // Might need to change this filepath once the game is built... this works for editing though
    string filePath = @"Assets\usersLogged.txt";
    // get userID and password input fields
    public GameObject userID;
    public GameObject difficulty;
    // 0 users in the game file at default... edit this as time goes on
    public static int numUsers = 0;
    public static string[] currUser;
    // load default settings
    public static bool reg = true;
    public void writeFile()
    {
        // Gets the input from the user
        string user = userID.GetComponent<TMP_InputField>().text;
       // string pass = password.GetComponent<TMP_InputField>().text;
        int diff = 0;
        Int32.TryParse(difficulty.GetComponent<TMP_InputField>().text, out diff);
        if(diff <= 0)
        {
            diff = 1;
        }
        else if(diff > 5)
        {
            diff = 5;
        }
        
        bool userExists = false;
        // If the file does not exist, create it
        if (!File.Exists(filePath))
        {
            using StreamWriter sw = File.CreateText(filePath);
            {
                sw.WriteLine("USERID,LEVEL,ACCURACY,SCORE,DIFFICULTY");
            }
        }
        // If the user is not in the file, add them
        using (StreamReader sr = new StreamReader(filePath))
        {
            // while we are not at the end of the file
            while(sr.Peek() > 0)
            {
                string currLine;
                string[] currData;
                currLine = sr.ReadLine();
                currData = currLine.Split(',');
                // Data looks like the following:
                // USERID,LEVEL,ACCURACY,SCORE,DIFFICULTY
                // we split based on , and check to see if userID and password match
                if (currData[0] == user)
                {
                    // What if the user changes their difficulty through multiple runs? Should we change this?
                    // TODO: ASK GROUP
                    currUser = currData;
                    userExists = true;
                }
            }
        }
        if (!userExists)
        {
            using StreamWriter sw = File.AppendText(filePath);
            {
                sw.Write(user);
                sw.Write(",");
                // Default values since it is a new user
                // Need to change difficulty according to settings
                // USERID,LEVEL,ACCURACY,SCORE,DIFFICULTY
                sw.Write("3,0,0,");
                sw.Write(diff);
                sw.Write("\n");
            }
            sw.Close();
            using StreamReader sread = new StreamReader(filePath);
            // while we are not at the end of the file
            while (sread.Peek() > 0)
            {
                string currLine;
                string[] currData;
                currLine = sread.ReadLine();
                currData = currLine.Split(',');
                // We added the user, assign currUser the proper data array
                if (currData[0] == user)
                {
                    currUser = currData;
                }
            }
            sread.Close();
            // Create a new entry for the user
        }
        else
        {
            // Do nothing for now until they save, we know the user already exists
            // Load the data already stored
        }
    }

    public void writeResults()
    {
        if (currUser == null)
        {
            return;
        }
        else
        {
            // Writes the results in the result file
            string user = currUser[0];
            int level = 0;
            Int32.TryParse(currUser[1], out level);
            float accuracy = (float)(AnswerChecker.numCorrect) / (float)(AnswerChecker.numAttempted);
            int score = 0;
            Int32.TryParse(currUser[3], out score);
            int diff = 0;
            Int32.TryParse(currUser[4], out diff);
            string filePath = @"Assets\userData.txt";
            if (!File.Exists(filePath))
            {
                using StreamWriter sw = File.CreateText(filePath);
                {
                    sw.WriteLine("USERID, LEVEL, ACCURACY, SCORE, DIFFICULTY");
                }
                sw.Close();
            }
            using StreamWriter sw2 = File.AppendText(filePath);
            {
                sw2.Write(user);
                sw2.Write(",");
                // Default values since it is a new user
                // Need to change difficulty according to settings
                // USERID,LEVEL,ACCURACY,SCORE,DIFFICULTY
                sw2.Write(level);
                sw2.Write(",");
                sw2.Write(accuracy);
                sw2.Write(",");
                sw2.Write(score);
                sw2.Write(",");
                sw2.Write(diff);
                sw2.Write("\n");
            }
            sw2.Close();
            Application.Quit();
        }
    }
}
