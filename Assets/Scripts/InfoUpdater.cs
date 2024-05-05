using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoUpdater : MonoBehaviour
{
    public GameObject vectorOne;
    public GameObject vectorTwo;
    public string DemoName;
    // scale down the whole model by a factor to fit on screen correctly
    private float scaleFactor = 5f;
    public GameObject vectorVisualization;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("info updater script started");
        if (DemoName == "demo2") {
            // translate the position of the square root symbol
            GameObject.Find("square_root1").transform.Translate(1f,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // // getting vector lengths
        float vectorOneLength = vectorOne.transform.localScale.x;
        float vectorTwoLength = vectorTwo.transform.localScale.x;

        // getting "real" vectors by multiplying their magnitude by their normalized direction vector
        Vector3 vecOne = vectorOne.transform.right * vectorOneLength;
        Vector3 vecTwo = vectorTwo.transform.right * vectorTwoLength;

        // scaling dot product by scale factor to make sure its accurate
        float dotProduct = Vector3.Dot(vecOne*scaleFactor, vecTwo*scaleFactor);

        // if demo 1 grab text component and update entire block
        if (DemoName == "demo1") {
            string text = "";

            text += "Find the dot product.";

            // getting + or - depending on sign of coordinate
            string signA = "";
            if (vecTwo.y < 0) {
                signA = "-";
            } else {
                signA = "+";
            }

            string signB = "";
            if (vecOne.y < 0) {
                signB = "-";
            } else {
                signB = "+";
            }

            // NOTE: multiplying by factor to offset the scale down we did to make model fit well on page
            text += "\na = " + (vecTwo.x * scaleFactor).ToString("F1") + "i " + signA + Mathf.Abs((vecTwo.y * scaleFactor)).ToString("F1") + "j		b = " + (vecOne.x * scaleFactor).ToString("F1") + "i " + signB + Mathf.Abs((vecOne.y * scaleFactor)).ToString("F1") + "j";

            text += "\na = a<sub>x</sub>i + a<sub>y</sub>j		b = b<sub>x</sub>i + b<sub>y</sub>j";

            text += "\na \u2022 b = a<sub>x</sub>b<sub>x</sub> + a<sub>y</sub>b<sub>y</sub>";

            text += "\n       = " + (vecTwo.x * scaleFactor).ToString("F1") + " (" + (vecOne.x * scaleFactor).ToString("F1") + ") + " + (vecTwo.y * scaleFactor).ToString("F1") + " (" + (vecOne.y * scaleFactor).ToString("F1") + ")";
            
            // calculating products
            float prodOne = (vecTwo.x * scaleFactor) * (vecOne.x * scaleFactor);
            float prodTwo = (vecTwo.y * scaleFactor) * (vecOne.y * scaleFactor);   

            text += "\n       = " + prodOne.ToString("F1") + " + " + prodTwo.ToString("F1") + " = " + dotProduct.ToString("F1");

            // setting the new text into the UI
            GameObject.Find("Text (TMP)").GetComponent<TMP_Text>().text = text;

        } else if (DemoName == "demo2"){
            string text = "";

            text += "Find the magnitude of each vector.";

            // getting + or - depending on sign of coordinate
            string sign = "";
            if (vecTwo.y < 0) {
                sign = "-";
            } else {
                sign = "+";
            }

            text += "\na = " + (vecTwo.x * scaleFactor).ToString("F1") + "i " + sign + Mathf.Abs((vecTwo.y * scaleFactor)).ToString("F1") + "j";

            text += "\n|a| =     a<sub>x</sub><sup>2</sup> + a<sub>y</sub><sup>2</sup>";
            text += "\n|a| =    " + (vecTwo.x * scaleFactor).ToString("F1") + "<sup>2</sup>" + sign + Mathf.Abs((vecTwo.y * scaleFactor)).ToString("F1") + "<sup>2</sup> =  ";
            text += "" + ((vecTwo.x * scaleFactor)*(vecTwo.x * scaleFactor)).ToString("F1") + " + " + ((vecTwo.y * scaleFactor)*(vecTwo.y * scaleFactor)).ToString("F1") + " =    ";
            text += ((vecTwo.x * scaleFactor)*(vecTwo.x * scaleFactor) + (vecTwo.y * scaleFactor)*(vecTwo.y * scaleFactor)).ToString("F1");
            text += "\n				= " + Mathf.Sqrt((vecTwo.x * scaleFactor)*(vecTwo.x * scaleFactor) + (vecTwo.y * scaleFactor)*(vecTwo.y * scaleFactor)).ToString("F1");

            // setting the new text into the UI
            GameObject.Find("Text (TMP)").GetComponent<TMP_Text>().text = text;
        }
        

        // // getting angle between vectors
        // float angleBetween = Vector3.SignedAngle(vectorOne.transform.right, vectorTwo.transform.right, new Vector3(0,0,1));
        // int angleRounded = Mathf.RoundToInt(angleBetween);

        // // getting "real" vectors by multiplying their magnitude by their normalized direction vector
        // Vector3 vecOne = vectorOne.transform.right * vectorOneLength;
        // Vector3 vecTwo = vectorTwo.transform.right * vectorTwoLength;
        // float dotProduct = Vector3.Dot(vecOne, vecTwo);

        // // checking which vector is currently selected (highlighted)
        // string selectedVector = "";
        // if (vectorOne.GetComponent<Outline>().enabled == true) {
        //     selectedVector = "Vector 1 (blue)";
        // } else {
        //     selectedVector = "Vector 2 (green)";
        // }

        // // setting the text of the UI (print all floats with precision 2)
        // GetComponent<TextMeshProUGUI>().text = 
        // "Blue vector length: " + vectorOneLength.ToString("F2") + 
        // "\nGreen vector length: " + vectorTwoLength.ToString("F2") +
        // "\nAngle: " + angleRounded.ToString() +
        // "\nDot product: " + dotProduct.ToString("F2") +
        // "\nSelected vector: " + selectedVector +
        // "\nBlue Vector Coordinates: <" + vecOne.x.ToString("F2") + "," + vecOne.y.ToString("F2") + ">" +
        // "\nGreen Vector Coordinates: <" + vecTwo.x.ToString("F2") + "," + vecTwo.y.ToString("F2") + ">";
    }
}
