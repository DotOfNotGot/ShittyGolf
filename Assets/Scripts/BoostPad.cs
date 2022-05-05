using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{

    private Rigidbody colliderRb;

    [SerializeField]
    private int boostForce;

    private void OnTriggerEnter(Collider other)
    {
        colliderRb = other.gameObject.GetComponent<Rigidbody>();

        colliderRb.velocity = transform.forward * boostForce;

    }
}
