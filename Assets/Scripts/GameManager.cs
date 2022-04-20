using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<BallController> ballControllers;

    private int assignedIndex;

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


    public void PlayerWon(int playerIndex)
    {
        Debug.Log(playerIndex + " won");
    }

}
