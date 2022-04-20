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

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.scene != SceneManager.GetSceneByName("Simulation"))
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Instantiate(ballLineRendererPrefab, transform.position, Quaternion.identity);
        }
    }

}
