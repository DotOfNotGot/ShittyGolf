using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;

    public int amountToPool;

    private Dictionary<GameObject, BallController> _ballControllersDict;

    private void Awake()
    {
        if (!SharedInstance)
        {
            SharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
        pooledObjects = new List<GameObject>();
        _ballControllersDict = new Dictionary<GameObject, BallController>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject GetPooledObject(int newPoolAmount)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public BallController GetPooledBallController(GameObject key)
    {
        if (_ballControllersDict.ContainsKey(key))
        {
            return _ballControllersDict[key];
        }

        return null;
    }
    
    public void PopulatePool(int amount)
    {
        amountToPool = amount;
        GameObject tmp;
        for (int i = 0; i < amount; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
            BallController tmpBallController = tmp.GetComponent<BallController>();
            if (tmpBallController)
            {
                _ballControllersDict.Add(tmp, tmpBallController);
            }
        }
    }
}
