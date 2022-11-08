using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Answer : MonoBehaviour
{
    public InputField UIInputField;
    public TMP_InputField TMPInputField;
    public bool renderState;

    void Start()
    {
        renderState = false;
        if (UIInputField != null)
            UIInputField.text = "This is a basic example";
        if (TMPInputField != null)
            TMPInputField.text = "This is a basic example";
    }

    void ToggleRender()
    {
        gameObject.SetActive(!renderState);
    }

    
}
