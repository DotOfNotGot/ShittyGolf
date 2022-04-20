using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(ballPrefab, transform.position, Quaternion.identity);

    }

}
