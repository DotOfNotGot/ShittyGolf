using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private GameObject ballLineRendererPrefab;

    public List<GameObject> ballGOs;


    private MainMenuHandler mainMenuHandler;

    private GameManager gameManager;

    private bool shouldSpawn;

    // Start is called before the first frame update
    void Awake()
    {

        mainMenuHandler = FindObjectOfType<MainMenuHandler>();

        gameManager = FindObjectOfType<GameManager>();

        if (!mainMenuHandler || mainMenuHandler.mode == 1)
        {
            GameObject newBall = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ballGOs.Add(newBall);
            shouldSpawn = false;
        }
        else if (mainMenuHandler.mode == 2)
        {
            GameObject newBall = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ballGOs.Add(newBall);
            shouldSpawn = true;
        }
        
        if (FindObjectOfType<LineProjection>() == null)
        {
            Instantiate(ballLineRendererPrefab, transform.position, Quaternion.identity);
        }

    }

    private void Update()
    {
        if (shouldSpawn && gameManager.currentTurnIndex == 1)
        {
            GameObject newBall = (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ballGOs.Add(newBall);
            shouldSpawn = false;
        }
    }

}
