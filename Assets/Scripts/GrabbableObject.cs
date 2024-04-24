using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private bool isGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grab(float triggerPress) {
        if (!isGrabbed) {
            isGrabbed = true;
        }
    }
}
