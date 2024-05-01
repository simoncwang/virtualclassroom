using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DrawText : MonoBehaviour
{
    // [SerializeField]
    public TMP_Text lessonContent;
    public string demo;

    private string[] lines;
    private string[] demo1_text = {"", "a = ai + 4j		b = 5i - 4j", "a \u2022 b = |a| |b| cos(theta)", "a \u2022 b = |a| |b|", "(a \u2022 b)/(|a| |b|) = "};
    private string[] demo2_text = {"", "a = ai + 4j		b = 5i - 4j", "a \u2022 b = |a| |b| cos(theta)", "a \u2022 b = |a| |b|", "(a \u2022 b)/(|a| |b|) = "};
    private string[] demo3_text = {"Find the angle between the two vectors. (scene 11 2)", "a = ai + 4j		b = 5i - 4j", "a \u2022 b = |a| |b| cos(theta)", "a \u2022 b = |a| |b|", "(a \u2022 b)/(|a| |b|) = "};

    private float[] timestamps; // numerical tutorial video timestamps
    private float[] demo1_time = {5f, 4f, 3f, 2f, 1f};
    private float[] demo2_time = {5f, 4f, 3f, 2f, 1f};
    private float[] demo3_time = {5f, 4f, 3f, 2f, 1f};

    void Start()
    {
        lessonContent = GetComponent<TMP_Text>();

        if (demo == "demo1")
        {

        } else if (demo == "demo2") {

        } else if (demo == "demo3") {
            // not sure why I couldn't initialize the array here...
            lines = demo3_text;
            timestamps = demo3_time;
        } else {
            Debug.LogError("Please specify \'demo1\', \'demo2\', or \'demo3\' in the Inspector window.");
        }

        StartCoroutine(AnimateLessonContent());
    }

    IEnumerator AnimateLessonContent()
    {
        lessonContent.text = lines[0]; // initialize first line (overrides)
        yield return new WaitForSeconds(timestamps[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            lessonContent.text += "\n" + lines[i];
            yield return new WaitForSeconds(timestamps[i]);
        }
    }
}
