using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LineProjection : MonoBehaviour
{
    public Scene simulationScene;
    private PhysicsScene physicsScene;

    private Transform objectsParent;

    [SerializeField]
    private LineRenderer line;
    public int maxPhysicsFrameIterations;



    private void Start()
    {
        ObjectPool.SharedInstance.PopulatePool(maxPhysicsFrameIterations);
        objectsParent = GameObject.FindGameObjectWithTag("StageParent").transform;
        CreatePhysicsScene();
    }

    public void CreatePhysicsScene()
    {
        simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        physicsScene = simulationScene.GetPhysicsScene();

        foreach (Transform obj in objectsParent)
        {
            var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
            foreach (var meshRenderer in ghostObj.GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.enabled = false;
            }
            
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
        }

    }

    public void SimulateTrajectory(BallController ballPrefab, Vector3 pos, Vector3 velocity)
    {
        GameObject ghostObj = ObjectPool.SharedInstance.GetPooledObject(maxPhysicsFrameIterations);
        
        if (!ghostObj)
        {
            return;
        }
        
        var ghostObjTransform = ghostObj.transform;
        BallController ghostBallController = ObjectPool.SharedInstance.GetPooledBallController(ghostObj);
            
        ghostObj.SetActive(true);
        ghostObjTransform.position = pos;
        ghostObjTransform.rotation = Quaternion.identity;
        SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
        
        ghostBallController.BallShootSimulation(velocity);

        line.positionCount = maxPhysicsFrameIterations;

        for (int i = 0; i < maxPhysicsFrameIterations; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime);
            line.SetPosition(i, ghostObj.transform.position);
        }

        ghostObj.gameObject.SetActive(false);
    }

    public void EnableLine()
    {
        ToggleLine(true);
    }

    public void DisableLine()
    {
        ToggleLine(false);
    }
    
    private void ToggleLine(bool enabled)
    {
        line.enabled = enabled;
    }

}
