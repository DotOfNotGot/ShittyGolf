using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLineRendererPosition : MonoBehaviour
{
    private GameManager gameManager;
    private MainMenuHandler mainMenuHandler;
    private PlayerSpawner playerSpawner;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        mainMenuHandler = FindObjectOfType<MainMenuHandler>();
        playerSpawner = FindObjectOfType<PlayerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSpawner.ballGOs[gameManager.currentTurnIndex] != null)
        {
            transform.position = playerSpawner.ballGOs[gameManager.currentTurnIndex].transform.position;
            transform.rotation = playerSpawner.ballGOs[gameManager.currentTurnIndex].transform.rotation;
        }
    }
}
