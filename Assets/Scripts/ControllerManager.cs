using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    private float laserWidth = 0.05f;
    private float laserMaxLength = 5f;
    private GameObject leftController;
    private GameObject rightController;
    
    // Start is called before the first frame update
    void Start()
    {   
        // initial parameters for laser line render
        Vector3[] laserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(laserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;

        // get references to left and right hand anchors
        leftController = transform.Find("TrackingSpace/LeftHandAnchor").gameObject;
        rightController = transform.Find("TrackingSpace/RightHandAnchor").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetTriggerPress();
    }
    void GetTriggerPress() {
        // float rightIndexTriggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch);
        // float leftIndexTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch);

        // get right hand and index trigger inputs
        float rightHandTriggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch);
        float rightIndexTriggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch);

        // get left hand and index trigger input
        float leftHandTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch);
        float leftIndexTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch);

        // get positions and directions of left and right controllers
        Vector3 rightPosition = rightController.transform.position;
        Vector3 rightDirection = rightController.transform.forward;
        Vector3 leftPosition = leftController.transform.position;
        Vector3 leftDirection = leftController.transform.forward;

        // if (rightIndexTriggerValue > 0f) {
        //     laserLineRenderer.enabled = true;
        //     ShootLaserFromOrigin( rightPosition, rightDirection, laserMaxLength);
        // } else if (leftIndexTriggerValue > 0f) {
        //     laserLineRenderer.enabled = true;
        //     ShootLaserFromOrigin( leftPosition, leftDirection, laserMaxLength);
        // } else {
        //     laserLineRenderer.enabled = false;
        // }

        if (rightIndexTriggerValue > 0f) {   // shoot laser from right hand and SCALE object hit  
            laserLineRenderer.enabled = true;
            ShootLaserFromOrigin( rightPosition, rightDirection, laserMaxLength, "scale");
        } else if (leftIndexTriggerValue > 0f) {   // shoot laser from left hand and SCALE object hit
            laserLineRenderer.enabled = true;
            ShootLaserFromOrigin( leftPosition, leftDirection, laserMaxLength, "scale");
        } else if (rightHandTriggerValue > 0f) {   // shoot laser from right hand and ROTATE object hit
            laserLineRenderer.enabled = true;
            ShootLaserFromOrigin( rightPosition, rightDirection, laserMaxLength, "rotate");
        } else if (leftHandTriggerValue > 0f) {   // shoot laser from left hand and ROTATE object hit
            laserLineRenderer.enabled = true;
            ShootLaserFromOrigin( leftPosition, leftDirection, laserMaxLength, "rotate");
        } else {   // if no trigger is pressed do not render a laser
            laserLineRenderer.enabled = false;
        }
    }

    void ShootLaserFromOrigin( Vector3 origin, Vector3 direction, float length, string operation)
	{
        // shoot a ray from origin to direction
		Ray ray = new Ray( origin, direction );
		RaycastHit hit;

        // end position set to max length by default
		Vector3 endPosition = origin + ( length * direction );

        // if an object is hit by the raycast
		if( Physics.Raycast( ray, out hit) ) {

            Debug.Log(hit.collider.gameObject.name);

            // set end position as hit point for laser
			endPosition = hit.point;

            if (operation == "scale") {
                // attempt to scale the object hit
                ScaleObject scaleScript = gameObject.GetComponent<ScaleObject>();
                if (scaleScript != null) {
                    // set color of laser to green
                    changeColor(laserLineRenderer, Color.green);
                    // scaleScript.scaleObject(hit, endPosition);
                }
            } else if (operation == "rotate") {
                // attempt to rotate the object hit
                RotateObject rotateScript = gameObject.GetComponent<RotateObject>();
                if (rotateScript != null) {
                    // set color of laser to red
                    changeColor(laserLineRenderer, Color.red);
                    // rotateScript.rotateObject(hit, endPosition);
                }
            }

            // // check which object is hit
            // if (hit.collider.gameObject.name == "RotateCCW") {
            //     // getting rotation script
            //     RotateObject rotateScript = gameObject.GetComponent<RotateObject>();

            //     // getting overall parent (the vector parent)
            //     GameObject parentObject = hit.collider.gameObject.transform.parent.gameObject;
            //     if (rotateScript != null) {
            //         rotateScript.rotateObject(parentObject, 1f);
            //     }
            // } else if (hit.collider.gameObject.name == "RotateCW") {
            //     // getting rotation script
            //     RotateObject rotateScript = gameObject.GetComponent<RotateObject>();

            //     // getting overall parent (the vector parent)
            //     GameObject parentObject = hit.collider.gameObject.transform.parent.gameObject;
            //     if (rotateScript != null) {
            //         rotateScript.rotateObject(parentObject, -1f);
            //     }
            // } else {
            //     ScaleObject scaleScript = gameObject.GetComponent<ScaleObject>();
            //     if (scaleScript != null) {
            //         // set color of laser to green
            //         laserLineRenderer.material.color = Color.green;
            //         scaleScript.scaleObject(hit, endPosition);
            //     }
            // }
		}

        // update start and end of line render
		laserLineRenderer.SetPosition( 0, origin );
		laserLineRenderer.SetPosition( 1, endPosition );
	}

    private void changeColor(LineRenderer lr, Color newColor) {
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(newColor, 0.0f), new GradientColorKey(newColor, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lr.colorGradient = gradient;
    }
}
