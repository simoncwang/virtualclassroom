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
                                    "	=",
                                    "dummy4",
                                    "dummy5"};

    private float[] durations; // numerical tutorial video durations
    private float[] demo1_time = {1f, 1f, 1f, 1f, 1f, 1f}; // index 0 is duration for ""
    private float[] demo2_time = {1f, 1f, 1f, 1f, 1f}; // index 0 is duration for ""
    private float[] demo3_time = {1f, 1f, 1f, 1f, 1f, 1f, 3f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f}; // index 0 is duration for "Now let's say if we have 2 vectors..."

    private GameObject cos;
    private GameObject theta;
    private GameObject numerator1;
    private TMP_Text numerator1TMP;
    private GameObject numerator2;
    private TMP_Text numerator2TMP;
    private GameObject denominator1;
    private TMP_Text denominator1TMP;
    private GameObject denominator2;
    private TMP_Text denominator2TMP;
    private GameObject denominator3;
    private TMP_Text denominator3TMP;
    private GameObject fraction1;
    private GameObject fraction2;
    private GameObject sqrt1;
    private GameObject sqrt_long1;
    private GameObject sqrt_long2;
    private GameObject sqrt_long3;
    // private string[] demo3_line3_text = {"a \u2022 b"};
    // private string[] demo3_line4_text = {};

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

            // line 2
            cos = GameObject.Find("cos"); // checked: not null
            cos.SetActive(false);
            theta = GameObject.Find("theta");
            theta.SetActive(false);

            // line 3
            numerator1 = GameObject.Find("TMP_numerator1");
            numerator1TMP = numerator1.GetComponent<TMP_Text>();
            // Debug.LogError("[numerator1TMP] " + numerator1TMP.text); // outputs string text
            numerator1TMP.enabled = false;
            fraction1 = GameObject.Find("fraction1");
            fraction1.SetActive(false);
            denominator1 = GameObject.Find("TMP_denominator1");
            denominator1TMP = denominator1.GetComponent<TMP_Text>();
            denominator1TMP.enabled = false;

            numerator2 = GameObject.Find("TMP_numerator2");
            numerator2TMP = numerator2.GetComponent<TMP_Text>();
            numerator2TMP.enabled = false;
            fraction2 = GameObject.Find("fraction2");
            fraction2.SetActive(false);
            sqrt_long1 = GameObject.Find("square_root_long1");
            sqrt_long1.SetActive(false);
            denominator2 = GameObject.Find("TMP_denominator2");
            denominator2TMP = denominator2.GetComponent<TMP_Text>();
            denominator2TMP.enabled = false;            
            sqrt_long2 = GameObject.Find("square_root_long2");
            sqrt_long2.SetActive(false);
            denominator3 = GameObject.Find("TMP_denominator3");
            denominator3TMP = denominator3.GetComponent<TMP_Text>();
            denominator3TMP.enabled = false;

            // line3Content = new GameObject[] {numerator1, fraction1, denominator1, numerator2, fraction2, sqrt_long1, sqrt_long2};

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
                if (i == 1) {  
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i]);
                }

                if (i == 2)
                {
                    cos.SetActive(true);
                    theta.SetActive(true);
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i]);                    
                }
                
                if (i == 3) {
                    /*** Sorry, bad implementation atm but at least it works ***/
                    int skip = 3;
                    numerator1TMP.text = numerator1TMP.text; // FIXME: change to demo3_line3_text content
                    numerator1TMP.enabled = true;
                    fraction1.SetActive(true);
                    denominator1TMP.text = denominator1TMP.text; // FIXME: change to demo3_line3_text content
                    denominator1TMP.enabled = true;
                    yield return new WaitForSeconds(durations[i+skip]);
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i+skip+1]);
                    numerator2TMP.text = numerator2TMP.text; // FIXME: change to demo3_line3_text content
                    numerator2TMP.enabled = true;
                    yield return new WaitForSeconds(durations[i+skip+2]);
                    fraction2.SetActive(true);
                    yield return new WaitForSeconds(durations[i+skip+3]);
                    denominator2TMP.text = denominator2TMP.text; // FIXME: change to demo3_line3_text content
                    denominator2TMP.enabled = true;
                    denominator3TMP.text = denominator3TMP.text; // FIXME: change to demo3_line3_text content
                    denominator3TMP.enabled = true;    
                    sqrt_long1.SetActive(true);                
                    sqrt_long2.SetActive(true);
                    yield return new WaitForSeconds(durations[i+skip+4]);

                }
                
                if (i == 4) {
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i]);
                }

                if (i == 5) {
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i]);
                }
            }
        }
    }
}
