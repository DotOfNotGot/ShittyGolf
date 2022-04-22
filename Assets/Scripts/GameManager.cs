using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<BallController> ballControllers;

    private int assignedIndex;

    public int currentTurnIndex;

    // Start is called before the first frame update
    void Start()
    {

        ballControllers = new List<BallController>(FindObjectsOfType<BallController>());

        foreach (var ballController in ballControllers)
        {
            ballController.playerIndex = assignedIndex;
            assignedIndex++;
        }
    }

    public void TurnHandler(int currentIndex)
    {
        if (currentIndex + 1 != ballControllers.Count)
        {
            currentTurnIndex = currentIndex + 1;
        }
        else
        {
            currentTurnIndex = 0;
        }
        
    }


    public void PlayerWon(int playerIndex)
    {
        Debug.Log(playerIndex + " won");
    }

}
