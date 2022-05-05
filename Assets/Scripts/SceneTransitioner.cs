using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;

    private bool shouldTransition;

    [SerializeField]
    private int framesInScene;

    private void Update()
    {
        if (shouldTransition)
        {
            shouldTransition = false;
            SceneManager.LoadScene(sceneIndex);
            sceneIndex++;
        }

        if (framesInScene > 100)
        {
            shouldTransition = true;
        }

    }

    private void FixedUpdate()
    {
        framesInScene++;
    }

}
