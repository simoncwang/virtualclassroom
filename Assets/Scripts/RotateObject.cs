using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // private Vector3 initialRotation;
    // private GameObject objectToRotate;
    // private LineRenderer laser;
    // private Vector3 anchorPosition;

    // Start is called before the first frame update
    void Start()
    {
        // laser = GetComponent<LineRenderer>();
    }

    public void rotateObject(GameObject objectToRotate, float sign) {
        // checking if object is rotatable
        RotatableObject rotatable = objectToRotate.GetComponent<RotatableObject>();
        if (rotatable) {
            // update z rotation of object by this amount
            objectToRotate.transform.Rotate(0,0,sign*20f*Time.deltaTime,Space.Self);
        }   
    }

    // public void rotateObject(RaycastHit hit, Vector3 endPosition) {
    //     // checking if object is rotatable
    //     RotatableObject rotatable = hit.collider.gameObject.GetComponent<RotatableObject>();
    //     if (rotatable && hit.collider) {
    //         // getting attributes of hit object
    //         anchorPosition = rotatable.objectAnchor.position;
    //         objectToRotate = hit.collider.gameObject;

    //         // getting right vector (x direction) of object
    //         Vector3 objectRight = objectToRotate.transform.right;

    //         // getting vector from hit point to pivot
    //         Vector3 anchorToHit = hit.point - anchorPosition;

    //         // getting angle between these vectors
    //         float angle = Vector3.Angle(objectRight, anchorToHit);

    //         // getting sign of angle between them
    //         float sign = Mathf.Sign(Vector3.Dot(Vector3.forward,Vector3.Cross(objectRight, anchorToHit)));

    //         // update z rotation of object by this amount
    //         objectToRotate.transform.Rotate(0,0,sign*angle*Time.deltaTime,Space.Self);
    //     }   
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
