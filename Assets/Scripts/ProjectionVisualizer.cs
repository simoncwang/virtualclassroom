using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionVisualizer : MonoBehaviour
{
    public GameObject vectorOne;
    public GameObject vectorTwo;
    public LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        // initial parameters for line render
        Vector3[] laserPositions = new Vector3[ 2 ] { Vector3.zero, Vector3.zero };
        line.SetPositions(laserPositions);
        line.startWidth = 0.02f;
        line.endWidth = 0.02f;

    }

    // Update is called once per frame
    void Update()
    {
        // getting vector lengths
        float vectorOneLength = vectorOne.transform.localScale.x;
        float vectorTwoLength = vectorTwo.transform.localScale.x;
        Debug.Log("length: " + vectorTwoLength);

        // getting "real" vectors
        Vector3 vecOne = vectorOne.transform.right * vectorOneLength;
        Vector3 vecTwo = vectorTwo.transform.right * vectorTwoLength;

        // getting projection of hit vector onto direction of the current vector
        Vector3 projection = Vector3.Project(vecTwo, vecOne);

        Debug.Log("vecTwo: " + vecTwo.x + "," + vecTwo.y);
        Debug.Log("projection: " + projection.x + "," + projection.y);

        // render the line from vector2 to projection onto vector one (scaling up by 2)
        Vector3[] newPositions = new Vector3[ 2 ] { vecTwo * 2, projection * 2};
        line.SetPositions(newPositions);
    }
}
