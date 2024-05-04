using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorInitializer : MonoBehaviour
{
    
    public float x;
    public float y;

    // scale down the whole model by a factor to fit on screen correctly
    private float scaleFactor = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // setting correct scale including factor
        float newXSCale = magnitude(x,y);
        newXSCale /= scaleFactor;
        transform.localScale = new Vector3(newXSCale,1,1);

        // setting correct angle in degrees
        Vector2 vector = new Vector2(x,y);
        Vector2 horizontal = new Vector2(1,0);

        float angle = Vector2.SignedAngle(horizontal,vector);

        transform.eulerAngles = new Vector3(0,0,angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // return the magnitude of a vector with the coordinates (x,y)
    private float magnitude(float x, float y) {
        return Mathf.Sqrt(x*x+y*y);
    }
}
