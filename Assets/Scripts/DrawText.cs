using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DrawText : MonoBehaviour
{
    // [SerializeField]
    // public TextMeshProUGUI lessonContent;
    public TMP_Text lessonContent;

    void Start()
    {
        lessonContent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (lessonContent != null)
        {
            lessonContent.text = "My first text!";
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found!");
        }
    }
}
