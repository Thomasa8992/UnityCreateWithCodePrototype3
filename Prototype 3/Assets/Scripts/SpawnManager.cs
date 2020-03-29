using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 obstacleSpawnPosition = new Vector3(30, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObstacle() {
        var gameOverIsTriggered = playerControllerScript.gameOver;
        if (!gameOverIsTriggered) {
            Instantiate(obstaclePrefab, obstacleSpawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
