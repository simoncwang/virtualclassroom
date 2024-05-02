using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVectorRotation : MonoBehaviour
{
    public GameObject vector;

    // Update is called once per frame
    void Update()
    {
        Vector3 newAngle = Vector3.zero;
        if (gameObject.name == "Line") {
            newAngle = new Vector3(0,0,vector.transform.eulerAngles.z + 90);
        } else {
            newAngle = new Vector3(0,0,vector.transform.eulerAngles.z);
        }
        transform.eulerAngles = newAngle;
    }
}
