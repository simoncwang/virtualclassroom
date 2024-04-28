using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    // private Vector3 initialScale;
    // // private float maxScale = 2.0f;
    // private GameObject objectToScale;
    // private LineRenderer laser;
    // private Vector3 anchorPosition;

    // Start is called before the first frame update
    void Start()
    {
        // laser = GetComponent<LineRenderer>();
    }

    public void scaleObject(GameObject objectToScale, Vector3 hitPosition) {
        // NOTE: vector from origin to hit is just the hit position (hit position - (0,0,0))

        // getting local position of hit in vector visualization coordinates
        GameObject vectorVisualization = GameObject.Find("VectorVisualization");
        Vector3 localHit = vectorVisualization.transform.InverseTransformPoint(hitPosition);

        // getting projection of hit vector onto direction of the current vector
        Vector3 projection = Vector3.Project(localHit, objectToScale.transform.right);

        // get difference between length of projection and length of our vector
        // float vectorLength = objectToScale.transform.localScale.x;
        // float projectionLength = projection.x;
        // float diff = Vector3.Distance(projection, Vector3.zero);

        float length = projection.magnitude;

        // scaling the vector
        objectToScale.transform.localScale = new Vector3(length/2f,1,1);   // divide by 2 since we scale relative to end of vector
    }

    // public void scaleObject(RaycastHit hit, Vector3 endPosition) {
    //     ScalableObject scalable = hit.collider.gameObject.GetComponent<ScalableObject>();
    //     if (scalable && hit.collider) {
    //         Debug.Log("object is scalable");
            
    //         // position of object anchor
    //         anchorPosition = scalable.objectAnchor.position;
    //         objectToScale = hit.collider.gameObject;
    //         initialScale = objectToScale.transform.localScale;
    //         scaleTowardsX(endPosition);
    //     }
    // }

    // private void scaleTowardsX(Vector3 endPosition) {
    //     float distance = Vector3.Distance(endPosition,anchorPosition);
    //     objectToScale.transform.localScale = new Vector3(distance/2f, initialScale.y, initialScale.z);
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
