using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadSceneOnClick : MonoBehaviour {
    public void LoadByData()
    {
        // USERID,PASSWORD,LEVEL,ACCURACY,HEALTH,TIME,DIFFICULTY
        string[] playerData = LoginWrite.currUser;
        // default level is level 3 (Level 1)
        int index = 3;
        Int32.TryParse(playerData[1], out index);
        Debug.Log(index);
        LoadByIndex(index);
    }
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
