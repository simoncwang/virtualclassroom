using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{   
    public GameObject OVRManager;
    // Start is called before the first frame update
    void Start()
    {
        // enable this script on start and disable controller manager script
        OVRManager.GetComponent<ControllerManager>().enabled = false;
        OVRManager.GetComponent<LineRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 10f) {
            // after 5 seconds disable this script and set back to original scale
            transform.localScale = new Vector3(1,1,1);
            OVRManager.GetComponent<ControllerManager>().enabled = true;
            OVRManager.GetComponent<LineRenderer>().enabled = true;
            this.enabled = false;
        }

        // update scale (multiply time by factor to control speed)
        Vector3 newScale = new Vector3(0.25f*Mathf.Sin(Time.time*0.5f) + 1.25f, 1, 1);
        transform.localScale = newScale;

    }
}
