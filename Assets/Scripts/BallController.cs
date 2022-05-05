using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float maxLobForce;
    [SerializeField]
    private float actualForce = 0.1f;
    [SerializeField]
    private float rotationSpeed;
    private Vector3 direction;

    private GameManager gameManager;

    public float barFillAmount;
    private Canvas forceBarCanvas;

    public int playerIndex;

    private Rigidbody ballRb;

    public bool win;

    [SerializeField]
    private bool isTurningLeft;
    [SerializeField]
    private bool isTurningRight;
    private bool shootInput;
    private bool shootTime;
    [SerializeField]
    private bool shouldAdd;
    [SerializeField]
    private bool shouldLob;
    private bool shouldSwitchTurn;


    private LineProjection lineProjection;
    [SerializeField]
    private BallController ballPrefab;
    private BallLineRendererPosition lineStartPosition;

    [SerializeField]
    private float lobAngle;

    private Vector3 oldEulerAngles;
    private Vector3 oldTransformPosition;


    // Start is called before the first frame update
    void Start()
    {
        forceBarCanvas = GetComponentInChildren<Canvas>();
        forceBarCanvas.enabled = false;
        oldEulerAngles = transform.rotation.eulerAngles;
        oldTransformPosition = transform.position;
        ballRb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        lineProjection = FindObjectOfType<LineProjection>();
        lineStartPosition = FindObjectOfType<BallLineRendererPosition>();

        if (FindObjectsOfType<BallController>().Length > 1)
        {
            playerIndex = 1;
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (!win && oldTransformPosition == transform.position && gameManager.currentTurnIndex == playerIndex)
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
                transform.rotation = Quaternion.Euler(-lobAngle, direction.y, direction.z);
            }
            else
            {
                transform.rotation = Quaternion.Euler(direction);
            }

            if (shouldSwitchTurn)
            {
                gameManager.TurnHandler(playerIndex);
                shouldSwitchTurn = false;
            }
            BallShoot();
            
        }
        if (oldEulerAngles != transform.rotation.eulerAngles)
        {
            oldEulerAngles = transform.rotation.eulerAngles;
        }
        if (oldTransformPosition != transform.position)
        {
            oldTransformPosition = transform.position;
        }
        else if (gameManager.currentTurnIndex != playerIndex)
        {
            forceBarCanvas.enabled = false;
        }
    }

    public void BallShoot()
    {
        float forceDivider = 50f;

        if (shootInput)
        {
            forceBarCanvas.enabled = true;
            if (shouldAdd && !shouldLob)
            {
                actualForce += maxForce / forceDivider;
            }
            else if(!shouldAdd && !shouldLob)
            {
                actualForce -= maxForce / forceDivider;
            }

            if (shouldAdd && shouldLob)
            {
                actualForce += maxLobForce / forceDivider;

            }
            else if (!shouldAdd && shouldLob)
            {
                actualForce += maxLobForce / forceDivider;
            }

        }

        if (actualForce >= maxForce && shouldAdd && !shouldLob)
        {
            shouldAdd = false;
        }
        else if (actualForce <= 0 && !shouldAdd && !shouldLob)
        {
            shouldAdd = true;
        }

        if (actualForce >= maxLobForce && shouldAdd && shouldLob)
        {
            shouldAdd = false;
        }
        else if (actualForce <= 0 && !shouldAdd && shouldLob)
        {
            shouldAdd = true;
        }

        if (!shouldLob)
        {
            barFillAmount = actualForce / maxForce;
        }
        if (shouldLob)
        {
            barFillAmount = actualForce / maxLobForce;
        }

        if (shootTime)
        {
            Debug.Log("final" + actualForce);
            ballRb.velocity = transform.forward * actualForce;
            actualForce = 0.1f;
            shootTime = false;
            shouldSwitchTurn = true;
        }

        // Trajectory line, checks if player is currently moving and if not renders a trajectoryline to show where player would go at the maxforce of their shot.

        if (oldTransformPosition == transform.position && !shouldSwitchTurn)
        {
            lineProjection.gameObject.GetComponent<LineRenderer>().enabled = true;
            if (!shouldLob)
            {
                lineProjection.SimulateTrajectory(ballPrefab, lineStartPosition.transform.position, lineStartPosition.transform.forward * maxForce);
            }
            if (shouldLob)
            {
                lineProjection.SimulateTrajectory(ballPrefab, lineStartPosition.transform.position, lineStartPosition.transform.forward * maxLobForce);
            }
        }
        else if(oldTransformPosition != transform.position || shouldSwitchTurn)
        {
            lineProjection.gameObject.GetComponent<LineRenderer>().enabled = false;
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
        if (gameManager.currentTurnIndex == playerIndex)
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
}
