using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    // public variables
    public LineRenderer laserLineRenderer;
    public GameObject Vector1;
    public GameObject Vector2;
    public Material rotateMaterial;
    public Material scaleMaterial;

    // private variables
    private float laserWidth = 0.05f;
    private float laserMaxLength = 5f;
    private GameObject leftController;
    private GameObject rightController;
    private GameObject currentVector;
    
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

        // initialize outlines to disabled
        Vector1.GetComponent<Outline>().enabled = false;
        Vector2.GetComponent<Outline>().enabled = false;

        // set default vector selection to vector 1
        currentVector = Vector1;
        Vector1.GetComponent<Outline>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetJoystick();
        GetTriggerPress();
    }

    void GetJoystick() {
        // getting thumbstick input values
        var rightValue = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick, OVRInput.Controller.Touch).x;
        var leftValue = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.Touch).x;
        
        // checking if thumbstick is pointing left or right
        if (rightValue > 0 || leftValue > 0) {   // highlight vector 1
            Vector1.GetComponent<Outline>().enabled = true;
            Vector2.GetComponent<Outline>().enabled = false;

            // update current vector
            currentVector = Vector1;
        } else if (rightValue < 0 || leftValue < 0) {   // highlight vector 2
            Vector2.GetComponent<Outline>().enabled = true;
            Vector1.GetComponent<Outline>().enabled = false;

            // update current vector
            currentVector = Vector2;
        }
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

            // set end position as hit point for laser
			endPosition = hit.point;

            if (operation == "scale") {
                // attempt to scale the object hit
                ScaleObject scaleScript = gameObject.GetComponent<ScaleObject>();
                if (scaleScript != null) {
                    // set color of laser to green
                    changeColor(laserLineRenderer, scaleMaterial);
                    scaleScript.scaleObject(currentVector, endPosition);
                }
            } else if (operation == "rotate") {
                // attempt to rotate the object hit
                RotateObject rotateScript = gameObject.GetComponent<RotateObject>();
                if (rotateScript != null) {
                    // set color of laser to red
                    changeColor(laserLineRenderer, rotateMaterial);

                    // rotate the current selected vector
                    rotateScript.rotateObject(currentVector, endPosition);
                }
            }
		}

        // update start and end of line render
		laserLineRenderer.SetPosition( 0, origin );
		laserLineRenderer.SetPosition( 1, endPosition );
	}

    private void changeColor(LineRenderer lr, Material newMaterial) {
        lr.material = newMaterial;
    }
}
