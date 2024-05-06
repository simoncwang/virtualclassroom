using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DotProductInfo : MonoBehaviour
{
    public GameObject vectorOne;
    public GameObject vectorTwo;
    public string lessonName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // getting vector lengths
        float vectorOneLength = vectorOne.transform.localScale.x;
        float vectorTwoLength = vectorTwo.transform.localScale.x;

        // getting angle between vectors
        float angleBetween = Vector3.SignedAngle(vectorOne.transform.right, vectorTwo.transform.right, new Vector3(0,0,1));
        int angleRounded = Mathf.RoundToInt(angleBetween);

        // getting "real" vectors by multiplying their magnitude by their normalized direction vector
        Vector3 vecOne = vectorOne.transform.right * vectorOneLength;
        Vector3 vecTwo = vectorTwo.transform.right * vectorTwoLength;
        float dotProduct = Vector3.Dot(vecOne, vecTwo);

        // checking which vector is currently selected (highlighted)
        string selectedVector = "";
        if (vectorOne.GetComponent<Outline>().enabled == true) {
            selectedVector = "Vector 1 (blue)";
        } else {
            selectedVector = "Vector 2 (green)";
        }

        //  +
        //     "\nBlue coordinates: <" + vecOne.x.ToString("F2") + "," + vecOne.y.ToString("F2") + ">" +
        //     "\nGreen coordinates: <" + vecTwo.x.ToString("F2") + "," + vecTwo.y.ToString("F2") + ">"

        // setting the text based on which lesson we are on
        if (lessonName == "lesson5") {
            GetComponent<TMP_Text>().text = 
            "Selected vector: " + selectedVector +
            "\nBlue length: " + vectorOneLength.ToString("F2") + 
            "\nGreen length: " + vectorTwoLength.ToString("F2") +
            "\nTriangle side length: " + Vector3.Distance(Vector3.Project(vecTwo, vecOne), Vector3.zero).ToString("F2") +
            "\nDot product = " + Vector3.Distance(Vector3.Project(vecTwo, vecOne), Vector3.zero).ToString("F2") + " x " + vectorOneLength.ToString("F2") + " = " + dotProduct.ToString("F2");
        } else if (lessonName == "lesson6") {
            GetComponent<TMP_Text>().text = 
            "Selected vector: " + selectedVector +
            "\nBlue length: " + vectorOneLength.ToString("F2") + 
            "\nGreen length: " + vectorTwoLength.ToString("F2") +
            "\nAngle: " + angleRounded.ToString() +
            "\nDot product: " + dotProduct.ToString("F2");
        } else if (lessonName == "lesson8") {
            GetComponent<TMP_Text>().text = 
            "Selected vector: " + selectedVector +
            "\nBlue length: " + vectorOneLength.ToString("F2") + 
            "\nGreen length: " + vectorTwoLength.ToString("F2") +
            "\nTriangle side length: " + Vector3.Distance(Vector3.Project(vecOne, vecTwo), Vector3.zero).ToString("F2") +
            "\nDot product = " + Vector3.Distance(Vector3.Project(vecOne, vecTwo), Vector3.zero).ToString("F2") + " x " + vectorTwoLength.ToString("F2") + " = " + dotProduct.ToString("F2");
        }
        
    }
}
