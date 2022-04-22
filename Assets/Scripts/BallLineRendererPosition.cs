using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLineRendererPosition : MonoBehaviour
{

    private List<BallController> ballControllers;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        ballControllers = new List<BallController>(FindObjectsOfType<BallController>());
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballControllers[gameManager.currentTurnIndex] != null)
        {
            transform.position = ballControllers[gameManager.currentTurnIndex].transform.position;
            transform.rotation = ballControllers[gameManager.currentTurnIndex].transform.rotation;
        }
    }
}
