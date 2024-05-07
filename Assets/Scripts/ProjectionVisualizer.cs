using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionVisualizer : MonoBehaviour
{
    public GameObject vectorOne;
    public GameObject vectorTwo;
    public Material material;

    private LineRenderer lineTwo;
    private Mesh mesh;
    private MeshRenderer meshRenderer;
    private Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        // initializing triangle mesh
        gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        vertices = new[] {Vector3.zero, Vector3.zero, Vector3.zero};

        mesh.vertices = vertices;
        mesh.triangles = new[] {0,1,2};
    }

    // Update is called once per frame
    void Update()
    {
        // getting vector lengths
        float vectorOneLength = vectorOne.transform.localScale.x;
        float vectorTwoLength = vectorTwo.transform.localScale.x;

        // getting "real" vectors
        Vector3 vecOne = vectorOne.transform.right * vectorOneLength;
        Vector3 vecTwo = vectorTwo.transform.right * vectorTwoLength;

        // getting dot product
        float dotProduct = Vector3.Dot(vecOne, vecTwo);

        // setting scale of dot product object to this value
        transform.Find("Dot Product").transform.localScale = new Vector3(dotProduct * vectorOneLength, 1, 1);

        // getting projection of hit vector onto direction of the current vector
        Vector3 projection = Vector3.Project(vecTwo, vecOne);

        // rendering the triangle
        // if (vecTwo.y > 0) {
        //     if (vecTwo.x < 0) {
        //         vertices = new[] {projection * 2.5f, vecTwo * 2.5f, Vector3.zero};
        //     } else {
        //         vertices = new[] {vecTwo * 2.5f, projection * 2.5f, Vector3.zero};
        //     }
        // } else {
        //     if (vecTwo.x < 0) {
        //         vertices = new[] {projection * 2.5f, Vector3.zero, vecTwo * 2.5f};
        //     } else {
        //         vertices = new[] {vecTwo * 2.5f, Vector3.zero, projection * 2.5f};
        //     }
        // }    
        vertices = new[] {projection * 2.5f, vecTwo * 2.5f, Vector3.zero};

        Debug.Log("vertex1: " + vertices[0] + "vertex2: " + vertices[1] + "vertex3: " + vertices[2]);

        // // get local coordinates of vectors
        // Vector3 localVecOne = transform.InverseTransformPoint(vecOne);
        // Vector3 localVecTwo = transform.InverseTransformPoint(vecTwo);


        // if (localVecTwo.y >= 0 && localVecOne.y >= 0) {   // if both y coords greater than zero
        //     if (localVecTwo.x >= 0 && localVecOne.x >= 0) {   // if both x coords greater than zero
        //         vertices = new[] {vecTwo * 2.5f, projection * 2.5f, Vector3.zero};
        //     } else {
        //         vertices = new[] {vecTwo * 2.5f, Vector3.zero, projection * 2.5f};
        //     }
        // } else {
        //     if (localVecTwo.x >= 0 && localVecOne.x >= 0) {
        //         vertices = new[] {projection * 2.5f, vecTwo * 2.5f, Vector3.zero};
        //     } else {
        //         vertices = new[] {projection * 2.5f, Vector3.zero, vecTwo * 2.5f};
        //     }
        // }
        
        
        mesh.vertices = vertices;

    }
}
