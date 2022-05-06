using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    private BallController ballController;
    private Rigidbody ballRb;

    private void OnTriggerEnter(Collider other)
    {

        ballController = other.GetComponent<BallController>();
        ballRb = other.GetComponent<Rigidbody>();
        ballController.transform.position = ballController.lastStillPosition;
        ballRb.velocity = new Vector3(0, 0, 0);


    }

}
