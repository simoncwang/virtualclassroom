using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{   
    public GameObject OVRManager;
    private Vector3 originalRotation;
    private Vector3 currentRotation;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        // disable controller manager script
        OVRManager.GetComponent<ControllerManager>().enabled = false;
        OVRManager.GetComponent<LineRenderer>().enabled = false;

        // set original rotation for reference
        originalRotation = transform.eulerAngles;

        // setting initial time to 0
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10f) {
            // after 10 seconds disable this script and set back to original rotation
            transform.eulerAngles = originalRotation;
            OVRManager.GetComponent<ControllerManager>().enabled = true;
            OVRManager.GetComponent<LineRenderer>().enabled = true;
            this.enabled = false;
        }

        // get new angle based on original angle (offset by 90 so it oscillates around y-axis like video)
        float angle = Mathf.Sin(Time.time*0.5f) * (90 - originalRotation.z) + 90;

        // set new rotation
        Vector3 newRotation = new Vector3(0, 0, angle);
        transform.eulerAngles = newRotation;

    }
}
