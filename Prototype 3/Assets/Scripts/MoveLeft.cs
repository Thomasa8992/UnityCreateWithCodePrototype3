using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float movementSpeed = 30;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        handleOutOfBoundsObstacle();

        handleGameOver();
    }

    private void handleOutOfBoundsObstacle() {
        var leftBoundary = -10;
        var positionIsOutOfBounds = transform.position.x < leftBoundary;
        var gameObjectTagIsObstacle = gameObject.CompareTag("Obstacle");
        var obstacleIsOutOfBounds = positionIsOutOfBounds && gameObjectTagIsObstacle;

        if (obstacleIsOutOfBounds) {
            Destroy(gameObject);
        }
    }

    private void handleGameOver() {
        var gameOverIsTriggered = playerControllerScript.gameOver;

        if (!gameOverIsTriggered) {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }
    }
}
