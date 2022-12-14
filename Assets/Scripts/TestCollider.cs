using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    public GameObject dialogue;
    //NEEDS TO BE SET FOR EVERY ENEMY IN EDITOR
    public int enemyScoreValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        dialogue.SetActive(true);
        DialogueBox.display = true;
        GridBasedPlayerMovement.toggleMovement();
        Enemy_Move.move = false;
        AnswerChecker.setEnemyScore(enemyScoreValue);
    }
/*    private void OnTriggerStay(Collider other)
    {
        ans.checkInput();
    }*/
    private void OnTriggerExit(Collider other)
    {
        dialogue.SetActive(false);
        DialogueBox.display = false;
    }
}
