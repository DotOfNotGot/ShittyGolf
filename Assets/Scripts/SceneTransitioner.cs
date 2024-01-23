using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;

    private bool shouldTransition;

    private void FixedUpdate()
    {
        if (shouldTransition)
        {
            shouldTransition = false;

            if (SceneManager.sceneCountInBuildSettings - 1 > sceneIndex)
            {
                sceneIndex++;
            }
            else
            {
                sceneIndex = 0;
            }

            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void OKButton(CallbackContext context)
    {
        shouldTransition = true;
    }

}
