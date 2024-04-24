using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    private Vector3 initialScale;
    // private float maxScale = 2.0f;
    private GameObject objectToScale;
    private LineRenderer laser;
    private Vector3 anchorPosition;

    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    public void scaleObject(RaycastHit hit, Vector3 endPosition) {
        ScalableObject scalable = hit.collider.gameObject.GetComponent<ScalableObject>();
        if (scalable && hit.collider) {
            Debug.Log("object is scalable");
            
            // position of object anchor
            anchorPosition = scalable.objectAnchor.position;
            objectToScale = hit.collider.gameObject;
            initialScale = objectToScale.transform.localScale;
            scaleTowardsX(endPosition);
        }
    }

    private void scaleTowardsX(Vector3 endPosition) {
        float distance = Vector3.Distance(endPosition,anchorPosition);
        objectToScale.transform.localScale = new Vector3(distance/2f, initialScale.y, initialScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
