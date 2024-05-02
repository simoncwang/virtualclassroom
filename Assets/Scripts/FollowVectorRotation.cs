using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVectorRotation : MonoBehaviour
{
    public GameObject vector;

    // Update is called once per frame
    void Update()
    {
        // setting the line's rotation to the same as the vector
        transform.eulerAngles = new Vector3(0,0,vector.transform.eulerAngles.z + 90);
    }
}
