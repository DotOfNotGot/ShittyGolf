using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLineRendererPosition : MonoBehaviour
{

    private BallController ballController;

    // Start is called before the first frame update
    void Start()
    {
        ballController = FindObjectOfType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballController != null)
        {
            transform.position = ballController.transform.position;
            transform.rotation = ballController.transform.rotation;
        }
    }
}
