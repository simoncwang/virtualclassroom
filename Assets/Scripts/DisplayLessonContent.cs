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
    private string[] demo1_text = {"Find the dot product.",
                                    "a = 3i + 4j		b = 5i - 2j",
                                    "a = a<sub>x</sub>i + a<sub>y</sub>j		b = b<sub>x</sub>i + b<sub>y</sub>j",
                                    "a \u2022 b = a<sub>x</sub>b<sub>x</sub> + a<sub>y</sub>b<sub>y</sub>",
                                    "        = 4 (-2) + -7 (3)",
                                    "        = -8 + -21 = -29"};
    private string[] demo2_text = {"Find the magnitude of each vector.",
                                    "a = 3i + 4j",
                                    "|a| =     a<sub>x</sub><sup>2</sup> + a<sub>y</sub><sup>2</sup>",
                                    "|a| =     3<sup>2</sup> + 4<sup>2</sup> =    9 + 16 =    25",
                                    "				= 5"};
    private string[] demo3_text = {"Find the angle between the two vectors. (scene 11 2)",
                                    "a = ai + 4j		b = 5i - 4j",
                                    "a \u2022 b = |a| |b|",
                                    ""};

    private float[] durations; // numerical tutorial video durations
    private float[] demo1_time = {1f, 1f, 1f, 1f, 1f, 1f}; // index 0 is duration for ""
    private float[] demo2_time = {1f, 1f, 1f, 1f, 1f}; // index 0 is duration for ""
    private float[] demo3_time = {1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f}; // index 0 is duration for "Now let's say if we have 2 vectors..."

    private GameObject cos;
    private GameObject theta;
    private GameObject numerator1;
    private GameObject numerator2;
    private GameObject denominator1;
    private GameObject fraction1;
    private GameObject fraction2;
    private GameObject sqrt1;
    private GameObject sqrt_long1;
    private GameObject sqrt_long2;
    private GameObject sqrt_long3;    
    GameObject[] line3Content; // for demo3

    void Start()
    {
        mainLessonContent = GameObject.Find("Text (TMP)");  // checked: not null
        mainlessonContentTMP = mainLessonContent.GetComponent<TMP_Text>(); // throwing errors fsr...

        if (demo == "demo1")
        {
            lines = demo1_text;
            durations = demo1_time;

            Debug.Assert(lines.Length == durations.Length, "Length of lines and durations should be equal.");

        } else if (demo == "demo2") {

            sqrt_long1 = GameObject.Find("square_root_long1");
            sqrt_long1.SetActive(false);
            sqrt_long2 = GameObject.Find("square_root_long2");
            sqrt_long2.SetActive(false);
            sqrt_long3 = GameObject.Find("square_root_long3");
            sqrt_long3.SetActive(false);
            sqrt1 = GameObject.Find("square_root1");
            sqrt1.SetActive(false);

            lines = demo2_text;
            durations = demo2_time;

            Debug.Assert(lines.Length == durations.Length, "Length of lines and durations should be equal.");

        } else if (demo == "demo3") {          

            cos = GameObject.Find("cos"); // checked: not null
            cos.SetActive(false);
            theta = GameObject.Find("theta");
            theta.SetActive(false);
            numerator1 = GameObject.Find("TMP (numerator1)");
            numerator1.SetActive(false);
            numerator2 = GameObject.Find("TMP (numerator2)");
            numerator2.SetActive(false);            
            fraction1 = GameObject.Find("fraction1");
            fraction1.SetActive(false);
            denominator1 = GameObject.Find("TMP (denominator1)");
            denominator1.SetActive(false);
            fraction1 = GameObject.Find("fraction1");
            fraction1.SetActive(false);
            fraction2 = GameObject.Find("fraction2");
            fraction2.SetActive(false);
            sqrt_long1 = GameObject.Find("square_root_long1");
            sqrt_long1.SetActive(false);
            sqrt_long2 = GameObject.Find("square_root_long2");
            sqrt_long2.SetActive(false);

            line3Content = new GameObject[] {numerator1, fraction1, denominator1, numerator2, fraction2, sqrt_long1, sqrt_long2};

            // not sure why I couldn't initialize the arrays here...
            lines = demo3_text;
            durations = demo3_time;

            // Debug.Assert(lines.Length == durations.Length, "Length of lines and durations should be equal.");

        } else {
            Debug.LogError("Please specify \'demo1\', \'demo2\', or \'demo3\' in the Inspector window.");
        }

        StartCoroutine(AnimateLessonContent());
    }

    IEnumerator AnimateLessonContent()
    {
        mainlessonContentTMP.text = lines[0]; // initialize first line (overrides)
        yield return new WaitForSeconds(durations[0]);

        if (demo == "demo1")
        {
            for (int i = 1; i < lines.Length; i++)
            {
                mainlessonContentTMP.text += "\n" + lines[i];
                yield return new WaitForSeconds(durations[i]);
            }
        }
        
        if (demo == "demo2")
        {
            for (int i = 1; i < lines.Length; i++)
            {
                if (i == 2)
                {
                    sqrt_long1.SetActive(true);
                }

                if (i == 3)
                {
                    sqrt_long2.SetActive(true);
                    sqrt_long3.SetActive(true);
                    sqrt1.SetActive(true);
                }

                mainlessonContentTMP.text += "\n" + lines[i];
                yield return new WaitForSeconds(durations[i]);
            }
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
                        line3Content[j].SetActive(true);
                        yield return new WaitForSeconds(durations[lines.Length + j]);
                    }
                } else {
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i]);
                }
            }
        }
    }
}