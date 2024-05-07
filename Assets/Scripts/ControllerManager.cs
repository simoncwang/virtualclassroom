using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerManager : MonoBehaviour
{
    // public variables
    public LineRenderer laserLineRenderer;
    public GameObject Vector1;
    public GameObject Vector2;
    public Material rotateMaterial;
    public Material scaleMaterial;
    public Material selectPointerMaterial;
    public Material defaultPointerMaterial;
    public string nextSceneName;
    private string currSceneName;
    public GameObject defaultVector;

    // private variables
    private float laserMaxLength = 5f;
    private GameObject leftController;
    private GameObject rightController;
    private GameObject currentVector;

    public bool enableInteraction;
    
    // Start is called before the first frame update
    void Start()
    {   
        // initial parameters for laser line render
        Vector3[] laserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(laserPositions);
        laserLineRenderer.startWidth = 0.01f;
        laserLineRenderer.endWidth = 0.05f;

        // get references to left and right hand anchors
        leftController = transform.Find("TrackingSpace/LeftHandAnchor").gameObject;
        rightController = transform.Find("TrackingSpace/RightHandAnchor").gameObject;

        // set default vector selection to vector 1
        currSceneName = SceneManager.GetActiveScene().name;
        if ((currSceneName != "ClassroomInitial") && (currSceneName != "ClassroomLesson8To9") && (currSceneName != "ClassroomLessonFinal") && (currSceneName != "LessonAnimationTest"))
        {
            // initialize outlines to disabled
            if (Vector1.GetComponent<Outline>()) {
                Vector1.GetComponent<Outline>().enabled = false;
            }
            
            if (Vector2.GetComponent<Outline>()) {
                Vector2.GetComponent<Outline>().enabled = false;
            }
            
            currentVector = defaultVector;
            if (currentVector.GetComponent<Outline>()) {
                currentVector.GetComponent<Outline>().enabled = true;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetJoystick();
        GetTriggerPress();
        Debug.Log("laser enabled: " + laserLineRenderer.enabled);
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

    bool GetButtonPress()
    {
        return OVRInput.GetDown(OVRInput.Button.One);
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

        if (enableInteraction) {
            if (rightIndexTriggerValue > 0f) {   // shoot laser from right hand and SCALE object hit  
                ShootLaserFromOrigin( rightPosition, rightDirection, laserMaxLength, "scale");
            } else if (leftIndexTriggerValue > 0f) {   // shoot laser from left hand and SCALE object hit
                ShootLaserFromOrigin( leftPosition, leftDirection, laserMaxLength, "scale");
            } else if (rightHandTriggerValue > 0f) {   // shoot laser from right hand and ROTATE object hit
                ShootLaserFromOrigin( rightPosition, rightDirection, laserMaxLength, "rotate");
            } else if (leftHandTriggerValue > 0f) {   // shoot laser from left hand and ROTATE object hit
                ShootLaserFromOrigin( leftPosition, leftDirection, laserMaxLength, "rotate");
            } else {   // if no trigger is pressed render default laser
                ShootLaserFromOrigin(rightPosition, rightDirection, laserMaxLength, "default");
            }
        } else {
            ShootLaserFromOrigin(rightPosition, rightDirection, laserMaxLength, "default");
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
            } else if (operation == "default") {
                if (hit.collider.gameObject.name.StartsWith("Arrow") ) {
                    changeColor(laserLineRenderer, selectPointerMaterial);   // change to select color while hitting arrow
                    if (GetButtonPress()) {   // if button pressesd
                        ChangeScene();
                    }
                } else if (hit.collider.gameObject.name.StartsWith("ExitButton")) { 
                    changeColor(laserLineRenderer, selectPointerMaterial);
                    if (GetButtonPress()) {   // if button pressesd
                        #if UNITY_STANDALONE
                            Application.Quit();
                        #endif
                        #if UNITY_EDITOR
                            UnityEditor.EditorApplication.isPlaying = false;
                        #endif
                    }
                } else {
                    changeColor(laserLineRenderer, defaultPointerMaterial);   // change back to default color
                    // if (GetButtonPress()) //  && (nextSceneName.StartsWith("ClassroomLesson9") || nextSceneName.StartsWith("ClassroomLesson10") || nextSceneName.StartsWith("ClassroomLesson11"))
                    // {
                    //     // Debug.Log("Current scene : " + currSceneName);
                    //     Debug.Log("Loading next scene...");
                    //     SceneManager.LoadScene(nextSceneName);
                    // }
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

    // load next scene
    void ChangeScene()
    {
        Debug.Log("Loading next scene...");
        SceneManager.LoadScene(nextSceneName);        
    }
}
