using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public List<string> lines = new List<string>();
    bool init = true;
    public static bool display = false;
    public static bool erase = false;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        /*textComponent.text = string.Empty;
        StartDialogue();*/
    }

    // Update is called once per frame
    void Update()
    {
        // bool to tell if we need to display the text
        if (display)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        // if this is the first time the box is showing, we need to push the question's text and its answer
        if (init)
        {
            string toAdd = "What is " + QuestionGenerator.questions.ElementAt(QuestionGenerator.randomIndex).Key + "?";
            lines.Add(toAdd);
        }
        // if the user clicks... this doesn't do much since we only have one question at a time
        if (Input.GetMouseButtonDown(0) || init)
        {
            init = false;
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        // if we got the question right and we need to delete the box, set vars and clean it up
        // we clear lines to erase old question
        if (erase)
        {
            display = false;
            init = true;
            gameObject.SetActive(false);
            erase = false;
            lines.Clear();
        }
    }
    // starts the dialogue process
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    // enumerates through the list of strings for dialogue
    IEnumerator TypeLine()
    {
        foreach (string c in lines)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    // gets the next line in lines() list
    void NextLine()
    { 
        if(index < lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
