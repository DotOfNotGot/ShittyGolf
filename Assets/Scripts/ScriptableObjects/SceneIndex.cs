using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneIndex", menuName = "SceneTransition")]
public class SceneIndex : ScriptableObject
{
    [SerializeField]
    int sceneIndex;

    public int _SceneIndex { get; set; }

}
