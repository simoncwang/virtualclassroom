using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DrawText : MonoBehaviour
{
    // [SerializeField]
    public TMP_Text lessonContent;
    /*** Bad implementation ***/
    // private string line1 = "My first text!";
    // private string line2 = "My second text!";
    // private string line3 = "My third text!";
    // private string line4 = "My fourth text!";
    private string[] lines = {"My first text!", "My second text!", "My third text!", "My fourth text!"};

    void Start()
    {
        lessonContent = GetComponent<TMP_Text>();

        // /*** 2. Better implementation - but doesn't achieve desired effect ***/
        // lessonContent.text = lines[0];

        StartCoroutine(AnimateLessonContent());
    }

    IEnumerator AnimateLessonContent()
    {
        lessonContent.text = lines[0];
        yield return new WaitForSeconds(5f);

        for (int i = 1; i < lines.Length; i++)
        {
            lessonContent.text = lines[i];
            yield return new WaitForSeconds(5f);
        }
    }

    // void Update()
    // {
    //     if (lessonContent != null)
    //     {
    //         /*** 1. Bad implementation ***/
    //         // lessonContent.text = line1;
    //         // // lessonContent.text += "\nsquare root symbol: " + "√";
    //         // lessonContent.text += line2;
    //         // lessonContent.text += line3;
    //         // lessonContent.text += line4;

    //         // /*** 2. Better implementation - but doesn't achieve desired effect ***/
    //         // for (int i = 1; i < lines.Length; i++)
    //         // {
    //         //     lessonContent.text += "\n" + lines[i];
    //         // }
    //     }
    //     else
    //     {
    //         // Debugging...
    //         Debug.LogError("TextMeshProUGUI component not found!");
    //     }
    // }
}
