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
            ChangeScene(); // change scene upon button press
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

    void RenderRay(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;
    }

    void CastRay()
    {
        // RenderRay(); // render default (white) ray at all times

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward.normalized, out hit, maxRayDistance))
        {
            hitObject = hit.collider.gameObject;
            Debug.Log("Ray hit [" + hitObject + "]");
            if (hitObject.name.StartsWith("Arrow")) // alternatively, .CompareTag("Next")
            {
                Debug.Log("current coordinate : " + transform.forward.normalized * maxRayDistance);
                Debug.Log("hit arrow coordinate : " + hitObject.transform.position);
                // Debug.Log("offset : " + (hitObject.transform.position - GameObject.Find("Arrow").transform.position)); // zero (!!!)
                SetRayMaterial(lineRenderer, selectPointerMaterial);
                RenderRay(transform.position, hitObject.transform.position);
            } else {
                SetRayMaterial(lineRenderer, defaultPointerMaterial); // change cast ray color back to default color
                RenderRay(transform.position, transform.forward * maxRayDistance); // render default (white) ray at all times
            }
        } else {
            Debug.Log("Ray hit nothing.");
            Debug.Log("current coordinate : " + transform.forward.normalized * maxRayDistance);
            SetRayMaterial(lineRenderer, defaultPointerMaterial); // change cast ray color back to default color
            RenderRay(transform.position, transform.forward * maxRayDistance); // render default (white) ray at all times
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
