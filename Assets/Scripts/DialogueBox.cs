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
    public static bool erase = false;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(init)
        {
            string toAdd = "What is " + QuestionGenerator.questions.ElementAt(QuestionGenerator.randomIndex).Key + "?";
            lines.Add(toAdd);
            init = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
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
            if (erase)
            {
                gameObject.SetActive(false);
            }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (string c in lines)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

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
