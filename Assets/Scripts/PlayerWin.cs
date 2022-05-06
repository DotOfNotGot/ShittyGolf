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


    // Makes ball that went into the hole win.
    private void OnTriggerEnter(Collider other)
    {
        ballRb = other.gameObject.GetComponent<Rigidbody>();
        ballController = other.gameObject.GetComponent<BallController>();
        ballGO = other.gameObject;

        simulationScene = SceneManager.GetSceneByName("Simulation");

        // Checks that the ball isn't in the simulation scene so that the trajectory line
        // Doesn't makes a player win.
        if (ballGO.scene != simulationScene)
        {
            gameManager = FindObjectOfType<GameManager>();

            // Disables gravity and sets velocity to 0 to make the hole seem like it has a bottom.
            ballRb.useGravity = false;
            ballRb.velocity = new Vector3(0, 0, 0);

            ballController.win = true;

            gameManager.PlayerWon(ballController.playerIndex);
        }

    }

}
