using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameManager gameManager;
    private PlayerSpawner playerSpawner;

    private BallController currentBallController;

    [SerializeField]
    private bool shouldLerp;

    private Transform ballTransform;
    private Vector3 cameraNextPosition;
    private Vector3 oldCameraPosition;

    [SerializeField]
    private float waitTime;

    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerSpawner = FindObjectOfType<PlayerSpawner>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (currentBallController == null)
        {
            currentBallController = playerSpawner.ballGOs[gameManager.currentTurnIndex].GetComponent<BallController>();
        }


        if (gameManager.currentTurnIndex != gameManager.previousFrameTurnIndex)
        {
            StartCoroutine(UpdateFollowTarget());
        }

        ballTransform = currentBallController.transform;

        cameraNextPosition = new Vector3(ballTransform.position.x + xOffset, ballTransform.position.y + yOffset, ballTransform.position.z - zOffset);

        if (shouldLerp)
        {
            transform.position = Vector3.Lerp(transform.position, cameraNextPosition, Time.deltaTime);
        }
        else
        {
            transform.position = cameraNextPosition;
        }

        if (transform.position == oldCameraPosition)
        {
            shouldLerp = false;
        }
        oldCameraPosition = transform.position;
    }

    private IEnumerator UpdateFollowTarget()
    {
       yield return new WaitForSeconds(waitTime);
       currentBallController = playerSpawner.ballGOs[gameManager.currentTurnIndex].GetComponent<BallController>();
       shouldLerp = true;
    }

}
