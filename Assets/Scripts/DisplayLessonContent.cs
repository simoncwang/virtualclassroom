using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DrawText : MonoBehaviour
{
    // [SerializeField]
    private GameObject mainLessonContent;
    private TMP_Text mainlessonContentTMP;
    public string demo;

    private string[] lines; // numerical tutorial video content
    private string[] demo1_text = {"", "a = ai + 4j		b = 5i - 4j", "a \u2022 b = |a| |b| cos(theta)", "a \u2022 b = |a| |b|", "(a \u2022 b)/(|a| |b|) = "};
    private string[] demo2_text = {"", "a = ai + 4j		b = 5i - 4j", "a \u2022 b = |a| |b| cos(theta)", "a \u2022 b = |a| |b|", "(a \u2022 b)/(|a| |b|) = "};
    private string[] demo3_text = {"Find the angle between the two vectors. (scene 11 2)",
                                    "a = ai + 4j		b = 5i - 4j",
                                    "a \u2022 b = |a| |b|",
                                    ""};

    private float[] durations; // numerical tutorial video durations
    private float[] demo1_time = {1f, 1f, 1f, 1f, 1f}; // index 0 is duration for ""
    private float[] demo2_time = {1f, 1f, 1f, 1f, 1f}; // index 0 is duration for ""
    private float[] demo3_time = {1f, 1f, 1f, 1f, 1f, 1f}; // index 0 is duration for "Now let's say if we have 2 vectors..."

    private List<GameObject> subLessonContent = new List<GameObject>();
    private GameObject cos;
    private GameObject theta;
    private GameObject numerator1;
    private GameObject numerator1;
    private GameObject numerator2;
    private GameObject denominator1;
    private GameObject fraction1;
    private GameObject fraction2;
    private GameObject sqrt_long1;
    private GameObject sqrt_long2;

    void Start()
    {
        mainLessonContent = GameObject.Find("Text (TMP)");  // checked: not null
        mainlessonContentTMP = mainLessonContent.GetComponent<TMP_Text>(); // throwing errors fsr...

        if (demo == "demo1")
        {

        } else if (demo == "demo2") {

        } else if (demo == "demo3") {
            cos = GameObject.Find("cos"); // checked: not null
            cos.SetActive(false);
            theta = GameObject.Find("theta");
            theta.SetActive(false);
            numerator1 = GameObject.Find("TMP (numerator1)");
            numerator1.SetActive(false);
            fraction1 = GameObject.Find("fraction1");
            fraction1.SetActive(false);
            denominator1 = GameObject.Find("TMP (denominator1)");
            denominator1.SetActive(false);

            // not sure why I couldn't initialize the arrays here...
            lines = demo3_text;
            durations = demo3_time;
        } else {
            Debug.LogError("Please specify \'demo1\', \'demo2\', or \'demo3\' in the Inspector window.");
        }

        // Debug.Assert(lines.Length == durations.Length, "Length of lines and durations should be equal.");

        StartCoroutine(AnimateLessonContent());
    }

    IEnumerator AnimateLessonContent()
    {
        mainlessonContentTMP.text = lines[0]; // initialize first line (overrides)
        yield return new WaitForSeconds(durations[0]);

        if (demo == "demo1")
        {

        }
        
        if (demo == "demo2")
        {

        }
        
        if (demo == "demo3")
        {
            for (int i = 1; i < lines.Length; i++)
            {
                if (i == 2)
                {
                    cos.SetActive(true);
                    theta.SetActive(true);
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i]);                    
                } else if (i == 3) {
                    for (int j = 0; j < durations.Length - lines.Length; j++)
                    {

                    }
                } else {
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i]);
                }
            }
        }
    }
}
