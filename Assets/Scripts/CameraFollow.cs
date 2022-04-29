using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameManager gameManager;

    private List<BallController> ballControllers;
    private BallController currentBallController;

    private Transform ballTransform;
    private Vector3 cameraNextPosition;

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
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (currentBallController == null)
        {
            currentBallController = gameManager.ballControllers[gameManager.currentTurnIndex];
        }


        if (gameManager.currentTurnIndex != gameManager.previousFrameTurnIndex)
        {
            StartCoroutine(UpdateFollowTarget());
        }

        ballTransform = currentBallController.transform;

        cameraNextPosition = new Vector3(ballTransform.position.x + xOffset, ballTransform.position.y + yOffset, ballTransform.position.z - zOffset);

        transform.position = Vector3.Lerp(transform.position, cameraNextPosition, Time.deltaTime);

        
    }

    private IEnumerator UpdateFollowTarget()
    {
       yield return new WaitForSeconds(waitTime);
       currentBallController = gameManager.ballControllers[gameManager.currentTurnIndex];
    }

}
