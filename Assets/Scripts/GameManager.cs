using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    private MainMenuHandler mainMenuHandler;


    public int currentTurnIndex;
    public int previousFrameTurnIndex;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuHandler = FindObjectOfType<MainMenuHandler>();
    }

    private void FixedUpdate()
    {
        previousFrameTurnIndex = currentTurnIndex;
    }

    public void TurnHandler(int currentIndex)
    {
        if (mainMenuHandler && currentIndex + 1 != mainMenuHandler.mode)
        {
            currentTurnIndex = currentIndex + 1;
        }
        else
        {
            currentTurnIndex = 0;
        }
        
    }

    private IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);

    }

    public void PlayerWon(int playerIndex)
    {
        Debug.Log(playerIndex + " won");
        StartCoroutine(LoadDelay());
    }

}
