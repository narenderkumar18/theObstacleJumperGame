using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnLoc = new Vector3(25, 0, 0);
    private float delayTime = 2;
    private float repeatTime = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnObstacle", delayTime, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[obstacleIndex], spawnLoc, obstaclePrefab[obstacleIndex].transform.rotation);
        }
    }
}
