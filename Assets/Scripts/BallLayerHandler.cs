using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLayerHandler : MonoBehaviour
{

    [SerializeField]
    private int layerOnTriggerEnter;
    [SerializeField]
    private int layerOnTriggerExit;

    // Changes layer of the ball object so that it stop colliding with the ground
    // allowing it to fall down into the hole
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = layerOnTriggerEnter;
        }
    }

    // Changes layer back to the Ball layer so that it can collide with the ground again.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = layerOnTriggerExit;
        }   
    }



}
