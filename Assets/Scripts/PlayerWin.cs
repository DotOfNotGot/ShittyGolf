using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{

    private Rigidbody ballRb;
    private BallController ballController;
    private GameObject ballGO;

    private Scene simulationScene;

    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {

        ballRb = other.gameObject.GetComponent<Rigidbody>();
        ballController = other.gameObject.GetComponent<BallController>();
        ballGO = other.gameObject;

        simulationScene = SceneManager.GetSceneByName("Simulation");

        if (ballGO.scene != simulationScene)
        {
            gameManager = FindObjectOfType<GameManager>();

            ballRb.useGravity = false;
            ballRb.velocity = new Vector3(0, 0, 0);

            ballController.win = true;

            gameManager.PlayerWon(ballController.playerIndex);
        }

    }

}
