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

        // translating certain text elements to make them fit the float numbers
        if (DemoName == "demo2") {
            GameObject.Find("square_root1").transform.Translate(1f,0,0);
        }

        if (DemoName == "demo3") {
            GameObject.Find("TMP_numerator2").transform.Translate(-1f,0,0);
            GameObject.Find("TMP_denominator3").transform.Translate(0.7f,0,0);
            GameObject.Find("square_root_long2").transform.Translate(0.7f,0,0);
            GameObject.Find("TMP_numerator3").transform.Translate(-0.5f,0,0);
            GameObject.Find("square_root_long4").transform.Translate(0.7f,0,0);
            GameObject.Find("TMP_denominator5").transform.Translate(0.7f,0,0);

            GameObject.Find("TMP_numerator4").transform.Translate(1.2f,0,0);
            GameObject.Find("fraction4").transform.Translate(1.2f,0,0);
            GameObject.Find("square_root1").transform.Translate(1.6f,0,0);
            GameObject.Find("TMP_denominator6").transform.Translate(1.2f,0,0);
            GameObject.Find("cos2").transform.Translate(1.3f,0,0);
            GameObject.Find("theta2").transform.Translate(1.3f,0,0);

            GameObject.Find("TMP_numerator5").transform.Translate(-0.3f,0,0);

            // enable additional square root symbol
            GameObject.Find("square_root3").SetActive(true);
            GameObject.Find("square_root3").transform.Translate(1.3f,0,0);

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
        } else if (DemoName == "demo3") {

            // getting all text elements that include numbers
            TMP_Text mainlessonContentTMP = GameObject.Find("Text (TMP)").GetComponent<TMP_Text>();
            TMP_Text numerator2TMP = GameObject.Find("TMP_numerator2").GetComponent<TMP_Text>();
            TMP_Text denominator2TMP = GameObject.Find("TMP_denominator2").GetComponent<TMP_Text>();
            TMP_Text denominator3TMP = GameObject.Find("TMP_denominator3").GetComponent<TMP_Text>();
            TMP_Text numerator3TMP = GameObject.Find("TMP_numerator3").GetComponent<TMP_Text>();
            TMP_Text denominator4TMP = GameObject.Find("TMP_denominator4").GetComponent<TMP_Text>();
            TMP_Text denominator5TMP = GameObject.Find("TMP_denominator5").GetComponent<TMP_Text>();
            TMP_Text numerator4TMP = GameObject.Find("TMP_numerator4").GetComponent<TMP_Text>();
            TMP_Text denominator6TMP = GameObject.Find("TMP_denominator6").GetComponent<TMP_Text>();
            TMP_Text numerator5TMP = GameObject.Find("TMP_numerator5").GetComponent<TMP_Text>();
            TMP_Text denominator7TMP = GameObject.Find("TMP_denominator7").GetComponent<TMP_Text>();

            // updating texts automatically when vectors are changed
            string text = "";

            // main text
            text += "Find the angle between the two vectors.";

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

            text += "\na = " + (vecTwo.x * scaleFactor).ToString("F1") + "i " + signA + Mathf.Abs((vecTwo.y * scaleFactor)).ToString("F1") + "j		b = " + (vecOne.x * scaleFactor).ToString("F1") + "i " + signB + Mathf.Abs((vecOne.y * scaleFactor)).ToString("F1") + "j";

            text += "\na \u2022 b = |a| |b|";
            text += "\n	=";
            text += "\n=			        =	    =";

            // updating the text
            mainlessonContentTMP.text = text;


            // numerator 2 text
            text = (vecTwo.x * scaleFactor).ToString("F1") + " (" + (vecOne.x * scaleFactor).ToString("F1") + ") + " + (vecTwo.y * scaleFactor).ToString("F1") + " (" + (vecOne.y * scaleFactor).ToString("F1") + ")";
            numerator2TMP.text = text;

            // denominator 2 text
            text = (vecTwo.x * scaleFactor).ToString("F1") + "<sup>2</sup> + " + (vecTwo.y * scaleFactor).ToString("F1") + "<sup>2</sup>";
            denominator2TMP.text = text;

            // denominator 3 text
            text = (vecOne.x * scaleFactor).ToString("F1") + "<sup>2</sup> + " + (vecOne.y * scaleFactor).ToString("F1") + "<sup>2</sup>";
            denominator3TMP.text = text;

            // numerator 3 text
            text = ((vecTwo.x * scaleFactor)*(vecOne.x * scaleFactor)).ToString("F1") + " + " + ((vecTwo.y * scaleFactor)*(vecOne.y * scaleFactor)).ToString("F1");
            numerator3TMP.text = text;

            // denominator 4 text
            float axsquare = (vecTwo.x * scaleFactor) * (vecTwo.x * scaleFactor);
            float aysquare = (vecTwo.y * scaleFactor) * (vecTwo.y * scaleFactor);

            text = axsquare.ToString("F1") + " + " + aysquare.ToString("F1");
            denominator4TMP.text = text;

            // denominator 5 text
            float bxsquare = (vecOne.x * scaleFactor) * (vecOne.x * scaleFactor);
            float bysquare = (vecOne.y * scaleFactor) * (vecOne.y * scaleFactor);

            text = bxsquare.ToString("F1") + " + " + bysquare.ToString("F1");
            denominator5TMP.text = text;

            // numerator 4 text
            float axbx = (vecTwo.x * scaleFactor)*(vecOne.x * scaleFactor);
            float ayby = (vecTwo.y * scaleFactor)*(vecOne.y * scaleFactor);
            text = (axbx + ayby).ToString("F1");
            numerator4TMP.text = text;

            // denominator 6 text
            text = (axsquare + aysquare).ToString("F1") + "  " + (bxsquare + bysquare).ToString("F1"); 
            denominator6TMP.text = text;

            // numerator 5 text
            text = (axbx + ayby).ToString("F1");
            numerator5TMP.text = text;
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
