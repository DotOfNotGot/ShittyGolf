using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangePosition : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D hole2DCollider;
    [SerializeField]
    private PolygonCollider2D ground2DCollider;
    [SerializeField]
    private MeshCollider generatedMeshCollider;
    [SerializeField]
    private float initialScale = 0.5f;

    private Mesh generatedMesh;
    private void Start()
    {
    }

    void FixedUpdate()
    {
        if (transform.hasChanged)
        {
            transform.hasChanged = false;
            hole2DCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            hole2DCollider.transform.localScale = transform.localScale * initialScale;
            MakeHole2D();
            Make3DMeshCollider();
        }
    }

    private void MakeHole2D()
    {
        Vector2[] pointPositions = hole2DCollider.GetPath(0);

        for (int i = 0; i < pointPositions.Length; i++)
        {
            pointPositions[i] = hole2DCollider.transform.TransformPoint(pointPositions[i]); 
        }

        ground2DCollider.pathCount = 2;
        ground2DCollider.SetPath(1, pointPositions);
    }

    private void Make3DMeshCollider()
    {
        if (generatedMesh != null)
        {
            Destroy(generatedMesh);
        }
        generatedMesh = ground2DCollider.CreateMesh(true, true);
        generatedMeshCollider.sharedMesh = generatedMesh;
    }
}
