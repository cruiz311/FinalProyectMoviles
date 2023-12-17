using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public SceneInfo[] sceneInfo;

    private void Start()
    {
        sceneInfo[Random.Range(0,sceneInfo.Length)].CreateSceneElements();
    }
}
