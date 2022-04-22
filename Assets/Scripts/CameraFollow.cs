using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private GameManager gameManager;

    private List<BallController> ballControllers;

    private Transform ballTransform;
    private Vector3 cameraNextPosition;

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
        ballTransform = gameManager.ballControllers[gameManager.currentTurnIndex].transform;
        cameraNextPosition = new Vector3(ballTransform.position.x + xOffset, ballTransform.position.y + yOffset, ballTransform.position.z - zOffset);

        transform.position = Vector3.Lerp(transform.position, cameraNextPosition, Time.deltaTime);
    }
}
