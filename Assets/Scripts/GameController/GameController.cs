using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Transform initSpawn;
    // Start is called before the first frame update
    void Start()
    {
        initSpawn = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
