using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    LineRenderer lineRenderer;
    GameObject hitObject;
    private float maxRayDistance = 20f;

    public Material defaultPointerMaterial; // maybe there's a better way to do this...?
    public Material selectPointerMaterial;

    public string sceneName;

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Next"))
    //     {
    //         SceneManager.LoadScene(sceneName);
    //     }
    // }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetRayMaterial(lineRenderer, defaultPointerMaterial);
    }

    void Update()
    {
        CastRay();

        if (GetButtonPress())
        {
            // ChangeScene(); // change scene upon button press
        }

        // if (GetButtonRelease())
        // {
            
        // }
    }

    bool GetButtonPress()
    {
        return OVRInput.GetDown(OVRInput.Button.One);
    }

    bool GetButtonRelease()
    {
        return OVRInput.GetUp(OVRInput.Button.One);
    }

    void RenderRay()
    {
        // Debug.Log("Controller position: " + transform.position + ", Controller forward: " + transform.forward.normalized);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.forward * maxRayDistance);
        lineRenderer.enabled = true;
    }

    void CastRay()
    {
        RenderRay(); // render default (white) ray at all times

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward.normalized, out hit, maxRayDistance))
        {
            hitObject = hit.collider.gameObject;
            Debug.Log("Ray hit [" + hitObject + "]");
            if (hitObject.name.StartsWith("Arrow")) // alternatively, .CompareTag("Next")
            {
                SetRayMaterial(lineRenderer, selectPointerMaterial);
            } else {
                SetRayMaterial(lineRenderer, defaultPointerMaterial); // change cast ray color back to default color
            }
        } else {
            Debug.Log("Ray hit nothing.");
        }
    }

    // load next scene
    void ChangeScene()
    {
        Debug.Log("Loading next scene...");
        SceneManager.LoadScene(sceneName);        
    }

    // change ray cast color to green upon hitting Next button
    // (though ig I could have changed just the color instead of the entire material...)
    void SetRayMaterial(LineRenderer LineRenderer, Material material)
    {
        LineRenderer.material = material;
    }
}
