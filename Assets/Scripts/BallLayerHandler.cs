using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLayerHandler : MonoBehaviour
{

    [SerializeField]
    private int layerOnTriggerEnter;
    [SerializeField]
    private int layerOnTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = layerOnTriggerEnter;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.layer = layerOnTriggerExit;
        }   
    }



}
