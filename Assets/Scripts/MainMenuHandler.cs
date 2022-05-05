using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject menuGameObject;

    public int mode;

    private void Start()
    {
        DontDestroyOnLoad(menuGameObject);
    }

    public void HandleOnePlayerMode()
    {
        mode = 1;
        SceneManager.LoadScene(1);
    }

    public void HandleTwoPlayerMode()
    {
        mode = 2;
        SceneManager.LoadScene(1);
    }

    

}
