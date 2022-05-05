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
            ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj, simulationScene);
        }

    }

    public void SimulateTrajectory(BallController ballPrefab, Vector3 pos, Vector3 velocity)
    {
        var ghostObj = ObjectPool.SharedInstance.GetPooledObject().GetComponent<BallController>();

        if (ghostObj != null)
        {
            ghostObj.gameObject.SetActive(true);
            ghostObj.transform.position = pos;
            ghostObj.transform.rotation = Quaternion.identity;
            SceneManager.MoveGameObjectToScene(ghostObj.gameObject, simulationScene);
        }
        else
        {
            return;
        }

        ghostObj.BallShootSimulation(velocity);

        line.positionCount = maxPhysicsFrameIterations;

        for (int i = 0; i < maxPhysicsFrameIterations; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime);
            line.SetPosition(i, ghostObj.transform.position);
            
        }

        ghostObj.gameObject.SetActive(false);
        ghostObj.transform.position = pos;
        ghostObj.transform.rotation = Quaternion.identity;
        ghostObj.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }

}
