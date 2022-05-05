using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    [SerializeField]
    private SceneIndex sceneIndex;

    private bool shouldTransition;

    [SerializeField]
    private int framesInScene;
    private void FixedUpdate()
    {

        if (framesInScene > 100)
        {
            shouldTransition = true;
        }

        if (shouldTransition)
        {
            shouldTransition = false;
            
            if (SceneManager.sceneCount < sceneIndex._SceneIndex)
            {
                sceneIndex._SceneIndex++;
            }
            else
            {
                sceneIndex._SceneIndex = 0;
            }

            SceneManager.LoadScene(sceneIndex._SceneIndex);

        }

        framesInScene++;
    }

}
