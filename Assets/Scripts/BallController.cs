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

    private float _currentMaxForce;
    
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
    private bool shouldCalculateLine = true;

    public Vector3 lastStillPosition;

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
        OnEnable();
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

            if (shouldCalculateLine)
            {
                lineProjection.SimulateTrajectory(ballPrefab, lineStartPosition.transform.position, lineStartPosition.transform.forward * _currentMaxForce);
                
                shouldCalculateLine = !(isTurningLeft && isTurningRight);
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
                actualForce -= maxLobForce / forceDivider;
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
            Debug.Log("final " + actualForce);
            ballRb.velocity = transform.forward * actualForce;
            actualForce = 0.1f;
            shootTime = false;
            shouldSwitchTurn = true;
        }

        // Checks if player is currently moving and if not renders a trajectory line to show where player would go at the max force of their shot.

        if (oldTransformPosition == transform.position && !shouldSwitchTurn)
        {
            lineProjection.EnableLine();
            lastStillPosition = transform.position;
        }
        else if(oldTransformPosition != transform.position || shouldSwitchTurn)
        {
            lineProjection.DisableLine();
        }

    }

    public void BallShootSimulation(Vector3 velocity)
    {
        ballRb.AddForce(velocity, ForceMode.Impulse);
    }

    private void HandleDeath()
    {
        transform.position = lastStillPosition;
        ballRb.velocity = new Vector3(0, 0, 0);
    }
    
    private void OnDisable()
    {
        ballRb.velocity = Vector3.zero;
    }

    private void OnEnable()
    {
        forceBarCanvas = GetComponentInChildren<Canvas>();
        forceBarCanvas.enabled = false;
        oldEulerAngles = transform.rotation.eulerAngles;
        oldTransformPosition = transform.position;
        ballRb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        lineProjection = FindObjectOfType<LineProjection>();
        lineStartPosition = FindObjectOfType<BallLineRendererPosition>();
        _currentMaxForce = maxForce;
        
        if (FindObjectsOfType<BallController>().Length > 1)
        {
            playerIndex = 1;
        }
    }

    public void AimInput(CallbackContext context)
    {
        if (oldTransformPosition == transform.position)
        {
            isTurningLeft = context.ReadValue<float>() < 0;
            isTurningRight = context.ReadValue<float>() > 0;
           
            if (context.ReadValue<float>() != 0)
            {
                shouldCalculateLine = true;
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
            _currentMaxForce = maxForce;
            shouldLob = false;
        }
        else if (context.started && !shouldLob)
        {
            _currentMaxForce = maxLobForce;
            shouldLob = true;
        }

        shouldCalculateLine = true;
    }


    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "DeathZone":
                HandleDeath();
                break;
        }
    }
}
