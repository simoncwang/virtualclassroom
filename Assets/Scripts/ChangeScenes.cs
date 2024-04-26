using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Next"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
