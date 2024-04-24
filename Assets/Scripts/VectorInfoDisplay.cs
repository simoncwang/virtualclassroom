using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
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
        float vectorOneLength = vectorOne.transform.localScale.x;
        float vectorTwoLength = vectorTwo.transform.localScale.x;
        GetComponent<TextMeshProUGUI>().text = "Vector 1 Length: " + vectorOneLength.ToString() + "\nVector 2 Length: " + vectorTwoLength.ToString();
    }
}
