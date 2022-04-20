using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private BallController ballController;

    private Transform ballTransform;

    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float zOffset;

    // Start is called before the first frame update
    void Start()
    {
        ballController = FindObjectOfType<BallController>();
        ballTransform = ballController.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(ballTransform.position.x + xOffset, ballTransform.position.y + yOffset, ballTransform.position.z - zOffset);
        
    }
}
