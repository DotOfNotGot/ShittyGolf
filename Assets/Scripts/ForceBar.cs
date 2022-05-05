using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceBar : MonoBehaviour
{

    private BallController ballController;

    [SerializeField]
    private Image forceBar;

    // Start is called before the first frame update
    void Start()
    {
        ballController = GetComponentInParent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        forceBar.fillAmount = ballController.barFillAmount;
    }
}
