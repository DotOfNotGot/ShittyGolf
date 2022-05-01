using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{

    private Rigidbody ballRb;
    private BallController ballController;

    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {

        ballRb = other.gameObject.GetComponent<Rigidbody>();
        ballController = other.gameObject.GetComponent<BallController>();

        gameManager = FindObjectOfType<GameManager>();

        ballRb.useGravity = false;
        ballRb.velocity = new Vector3(0, 0, 0);

        ballController.win = true;

        gameManager.PlayerWon(ballController.playerIndex);

    }

}
