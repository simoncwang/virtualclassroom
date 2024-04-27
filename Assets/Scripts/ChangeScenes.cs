using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    LineRenderer lineRenderer;
    public string sceneName;
    private float maxRayDistance = 15f;

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
    }

    void Update()
    {
        RenderRay(); // render red ray at all times
    
        // if (GetButtonPress())
        // {
        //     CastRay();
        // }

        // if (GetButtonRelease())
        // {
        //     lineRenderer.enabled = false;
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
        Debug.Log("Controller position: " + transform.position + ", Controller forward: " + transform.forward.normalized);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.forward * maxRayDistance);
        lineRenderer.enabled = true;
    }

    void SetRayColor()
    {

    }

    // void CastRay()
    // {
    //     RaycastHit hit;
    //     if (Physics.Raycast(transform.position, transform.forward.normalized, out hit, maxRayDistance))
    //     {
    //         GameObject hitObject = hit.collider.gameObject;
    //         Debug.Log("Ray hit [" + hitObject + "]");
    //         if (hitObject.CompareTag("Next"))
    //         {
    //             lineRenderer.SetPosition(1, hitObject.transform.position);
    //             lineRenderer.enabled = true;

    //             Debug.Log("Loading next scene...");
    //             SceneManager.LoadScene(sceneName);
    //         }
    //     } else {
    //         Debug.Log("Ray hit nothing.");
    //     }
    // }
}
