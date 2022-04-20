using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private float maxForce;
    private float actualForce = 0.1f;
    [SerializeField]
    private float rotationSpeed;
    private Vector3 direction;

    private GameManager gameManager;

    public float barFillAmount;

    public int playerIndex;

    private Rigidbody ballRb;

    public bool win;

    [SerializeField]
    private bool isTurningLeft;
    [SerializeField]
    private bool isTurningRight;
    private bool shootInput;
    private bool shootTime;
    private bool shouldAdd;
    private bool shouldLob;

    private LineProjection lineProjection;
    [SerializeField]
    private BallController ballPrefab;
    private BallLineRendererPosition lineStartPosition;

    private Vector3 oldEulerAngles;
    private Vector3 oldTransformPosition;

    // Start is called before the first frame update
    void Start()
    {
        oldEulerAngles = transform.rotation.eulerAngles;
        oldTransformPosition = transform.position;
        ballRb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        lineProjection = FindObjectOfType<LineProjection>();
        lineStartPosition = FindObjectOfType<BallLineRendererPosition>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!win)
        {
            if (isTurningLeft)
            {
                direction.y -= rotationSpeed;
            }
            else if (isTurningRight)
            {
                direction.y += rotationSpeed;
            }

            if (shouldLob)
            {
                transform.rotation = Quaternion.Euler(-45, direction.y, direction.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(direction);
            }


            BallShoot();
        }
        
        
    }

    public void BallShoot()
    {
        if (shootInput)
        {
            if (shouldAdd)
            {
                actualForce += 0.5f;
            }
            else
            {
                actualForce -= 0.5f;
            }
            
        }

        if (actualForce >= maxForce && shouldAdd)
        {
            shouldAdd = false;
        }
        else if (actualForce <= 0 && !shouldAdd)
        {
            shouldAdd = true;
        }

        barFillAmount = actualForce / maxForce;
        

        if (shootTime)
        {
            Debug.Log("final" + actualForce);
            ballRb.velocity = transform.forward * actualForce;
            actualForce = 0.1f;
            shootTime = false;
        }

        // Trajectory line, checks if player is currently moving and if not renders a trajectoryline to show where player would go at the maxforce of their shot.

        if (oldTransformPosition == transform.position)
        {
            lineProjection.gameObject.GetComponent<LineRenderer>().enabled = true;
            lineProjection.SimulateTrajectory(ballPrefab, lineStartPosition.transform.position, lineStartPosition.transform.forward * maxForce);
        }
        else if(oldTransformPosition != transform.position)
        {
            lineProjection.gameObject.GetComponent<LineRenderer>().enabled = false;
        }

        if (oldEulerAngles != transform.rotation.eulerAngles)
        {
            oldEulerAngles = transform.rotation.eulerAngles;
        }
        if (oldTransformPosition != transform.position)
        {
            oldTransformPosition = transform.position;
        }

    }

    public void BallShootSimulation(Vector3 velocity)
    {
        ballRb = GetComponent<Rigidbody>();
        ballRb.AddForce(velocity, ForceMode.Impulse);
    }

    public void AimInput(CallbackContext context)
    {
        if (oldTransformPosition == transform.position)
        {
            if (context.ReadValue<float>() < 0)
            {
                isTurningLeft = true;
            }
            else
            {
                isTurningLeft = false;
            }

            if (context.ReadValue<float>() > 0)
            {
                isTurningRight = true;
            }
            else
            {
                isTurningRight = false;
            }
        }
        else
        {
            isTurningLeft = false;
            isTurningRight = false;
        }
        

    }

    public void ShootButton(CallbackContext context)
    {
        if (context.started && shootInput)
        {
            shootTime = true;
            shootInput = false;
        }
        else if (context.started && !shootInput)
        {
            shootInput = true;
        }
    }

    public void LobButton(CallbackContext context)
    {
        if (context.started && shouldLob)
        {
            shouldLob = false;
        }
        else if (context.started && !shouldLob)
        {
            shouldLob = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Hole")
        {
            ballRb.useGravity = false;
            ballRb.velocity = new Vector3(0, 0, 0);

            win = true;

            gameManager.PlayerWon(playerIndex);
        }

    }

}
