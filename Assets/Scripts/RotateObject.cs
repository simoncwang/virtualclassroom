using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void rotateObject(GameObject objectToRotate, Vector3 hitPosition) {
        // NOTE: vector from origin to hit point is just hit position - (0,0,0) which is hit position
        Debug.Log(hitPosition);

        // getting local position of hit in vector visualization coordinates
        GameObject vectorVisualization = GameObject.Find("VectorVisualization");
        Vector3 localHit = vectorVisualization.transform.InverseTransformPoint(hitPosition);

        // getting angle between hit direction and horizontal axis
        float newAngle = Vector3.SignedAngle(localHit, new Vector3(1,0,0), new Vector3(0,1,0));

        // setting the z rotation of the object to this new angle
        objectToRotate.transform.eulerAngles = new Vector3(0,0,newAngle);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
