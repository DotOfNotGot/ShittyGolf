using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{

    private bool isMovingUp;
    private bool isMovingDown;
    private bool isMovingLeft;
    private bool isMovingRight;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    isMovingDown = true;
        //}
        //else
        //{
        //    isMovingDown = false;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    isMovingLeft = true;
        //}
        //else
        //{
        //    isMovingLeft = false;
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    isMovingUp = true;
        //}
        //else
        //{
        //    isMovingUp = false;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    isMovingRight = true;
        //}
        //else
        //{
        //    isMovingRight = false;
        //}

    }

    private void FixedUpdate()
    {
        if (isMovingDown)
        {
            position.z--;
            position.x++;
        }
        if (isMovingLeft)
        {
            position.x--;
            position.z--;
        }
        if (isMovingUp)
        {
            position.z++;
            position.x--;
        }
        if (isMovingRight)
        {
            position.x++;
            position.z++;
        }

        // transform.position = position;

    }

}
