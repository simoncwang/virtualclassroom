using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DotProductInfo : MonoBehaviour
{
    public GameObject vectorOne;
    public GameObject vectorTwo;

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

        // setting the text of the UI (print all floats with precision 2)
        GetComponent<TextMeshProUGUI>().text = 
        "Blue vector length: " + vectorOneLength.ToString("F2") + 
        "\nGreen vector length: " + vectorTwoLength.ToString("F2") +
        "\nAngle: " + angleRounded.ToString() +
        "\nDot product: " + dotProduct.ToString("F2") +
        "\nSelected vector: " + selectedVector +
        "\nBlue Vector Coordinates: <" + vecOne.x.ToString("F2") + "," + vecOne.y.ToString("F2") + ">" +
        "\nGreen Vector Coordinates: <" + vecTwo.x.ToString("F2") + "," + vecTwo.y.ToString("F2") + ">";
    }
}
