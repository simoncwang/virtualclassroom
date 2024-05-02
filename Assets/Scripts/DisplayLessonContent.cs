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
                                    "=",
                                    ""};

    private float[] durations; // numerical tutorial video durations
    private float[] demo1_time = {1f, 1f, 1f, 1f, 1f, 1f}; // index 0 is duration for ""
    private float[] demo2_time = {1f, 1f, 1f, 1f, 1f}; // index 0 is duration for ""
    private float[] demo3_time = {1f, 1f, 1f, 1f, 1f, 1f,  // index 0 is duration for "Now let's say if we have 2 vectors..."
                                    1f, 1f, 1f, 1f, 1f,
                                    1f, 1f, 1f, 1f,
                                    1f, 1f, 1f};

    // private string[] demo3_line3_text = {"a \u2022 b"};
    // private string[] demo3_line4_text = {};
    // private string[] demo3_line5_text = {};

    private GameObject cos1;
    private GameObject cos2;
    private GameObject cos3;
    private GameObject inv_cos;

    private GameObject theta1;
    private GameObject theta2;
    private GameObject theta3;

    private GameObject numerator1;
    private TMP_Text numerator1TMP;
    private GameObject numerator2;
    private TMP_Text numerator2TMP;
    private GameObject numerator3;
    private TMP_Text numerator3TMP;
    private GameObject numerator4;
    private TMP_Text numerator4TMP;
    private GameObject numerator5;
    private TMP_Text numerator5TMP;

    private GameObject denominator1;
    private TMP_Text denominator1TMP;
    private GameObject denominator2;
    private TMP_Text denominator2TMP;
    private GameObject denominator3;
    private TMP_Text denominator3TMP;
    private GameObject denominator4;
    private TMP_Text denominator4TMP;
    private GameObject denominator5;
    private TMP_Text denominator5TMP;
    private GameObject denominator6;
    private TMP_Text denominator6TMP;
    private GameObject denominator7;
    private TMP_Text denominator7TMP;

    private GameObject fraction1;
    private GameObject fraction2;
    private GameObject fraction3;
    private GameObject fraction4;
    private GameObject fraction5;

    private GameObject sqrt1;
    private GameObject sqrt2;
    private GameObject sqrt_long1;
    private GameObject sqrt_long2;
    private GameObject sqrt_long3;
    private GameObject sqrt_long4;

    private GameObject line5;
    private TMP_Text line5TMP;
    private string[] line5_text = {"=", "     = 91.79\u00B0"};

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
            cos1 = GameObject.Find("cos1"); // checked: not null
            cos1.SetActive(false);
            theta1 = GameObject.Find("theta1");
            theta1.SetActive(false);

            // line 3
            numerator1 = GameObject.Find("TMP_numerator1");
            numerator1TMP = numerator1.GetComponent<TMP_Text>();
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

            // line 4
            numerator3 = GameObject.Find("TMP_numerator3");
            numerator3TMP = numerator3.GetComponent<TMP_Text>();
            numerator3TMP.enabled = false;
            fraction3 = GameObject.Find("fraction3");
            fraction3.SetActive(false);
            sqrt_long3 = GameObject.Find("square_root_long3");
            sqrt_long3.SetActive(false);
            denominator4 = GameObject.Find("TMP_denominator4");
            denominator4TMP = denominator4.GetComponent<TMP_Text>();
            denominator4TMP.enabled = false;
            sqrt_long4 = GameObject.Find("square_root_long4");
            sqrt_long4.SetActive(false);
            denominator5 = GameObject.Find("TMP_denominator5");
            denominator5TMP = denominator5.GetComponent<TMP_Text>();
            denominator5TMP.enabled = false;

            numerator4 = GameObject.Find("TMP_numerator4");
            numerator4TMP = numerator4.GetComponent<TMP_Text>();
            numerator4TMP.enabled = false;
            fraction4 = GameObject.Find("fraction4");
            fraction4.SetActive(false);
            sqrt1 = GameObject.Find("square_root1");
            sqrt1.SetActive(false);
            denominator6 = GameObject.Find("TMP_denominator6");
            denominator6TMP = denominator6.GetComponent<TMP_Text>();
            denominator6TMP.enabled = false;

            cos2 = GameObject.Find("cos2");
            cos2.SetActive(false);
            theta2 = GameObject.Find("theta2");
            theta2.SetActive(false);

            // line 5
            theta3 = GameObject.Find("theta3");
            theta3.SetActive(false);
            line5 = GameObject.Find("line5");
            line5TMP = line5.GetComponent<TMP_Text>();
            line5TMP.enabled = false;
            numerator5 = GameObject.Find("TMP_numerator5");
            numerator5TMP = numerator5.GetComponent<TMP_Text>();
            numerator5TMP.enabled = false;
            fraction5 = GameObject.Find("fraction5");
            fraction5.SetActive(false);
            sqrt2 = GameObject.Find("square_root2");
            sqrt2.SetActive(false);
            denominator7 = GameObject.Find("TMP_denominator7");
            denominator7TMP = denominator7.GetComponent<TMP_Text>();
            denominator7TMP.enabled = false;
            inv_cos = GameObject.Find("inv_cos");
            inv_cos.SetActive(false);

            lines = demo3_text;
            durations = demo3_time;

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
                    cos1.SetActive(true);
                    theta1.SetActive(true);
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
                    int skip = 7;
                    mainlessonContentTMP.text += "\n" + lines[i];
                    yield return new WaitForSeconds(durations[i+skip]);                    
                    numerator3TMP.text = numerator3TMP.text; // FIXME: 
                    numerator3TMP.enabled = true;
                    fraction3.SetActive(true);
                    sqrt_long3.SetActive(true);                    
                    denominator4TMP.text = denominator4TMP.text; // FIXME: 
                    denominator4TMP.enabled = true;
                    sqrt_long4.SetActive(true);
                    denominator5TMP.text = denominator5TMP.text; // FIXME: 
                    denominator5TMP.enabled = true;
                    yield return new WaitForSeconds(durations[i+skip+1]);
                    mainlessonContentTMP.text += "			=";
                    numerator4TMP.text = numerator4TMP.text; // FIXME: 
                    numerator4TMP.enabled = true;
                    fraction4.SetActive(true);
                    denominator6TMP.text = denominator6TMP.text; // FIXME: 
                    denominator6TMP.enabled = true;
                    sqrt1.SetActive(true);
                    yield return new WaitForSeconds(durations[i+skip+2]);
                    mainlessonContentTMP.text += "	     =";
                    cos2.SetActive(true);
                    theta2.SetActive(true);
                    yield return new WaitForSeconds(durations[i+skip+3]);
                }

                if (i == 5) {
                    int skip = 10;
                    theta3.SetActive(true);
                    yield return new WaitForSeconds(durations[i+skip]);
                    line5TMP.text = line5_text[0];
                    line5TMP.enabled = true;
                    yield return new WaitForSeconds(durations[i+skip+1]);
                    inv_cos.SetActive(true);
                    numerator5TMP.text = numerator5TMP.text; // FIXME: 
                    numerator5TMP.enabled = true;
                    fraction5.SetActive(true);
                    sqrt2.SetActive(true);
                    denominator7TMP.text = denominator7TMP.text; // FIXME: 
                    denominator7TMP.enabled = true;
                    yield return new WaitForSeconds(durations[i+skip+2]);
                    line5TMP.text += "\n" + line5_text[1];
                }
            }
        }
    }
}
