using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool playerIsOnTheGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && playerIsOnTheGround) {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerIsOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.collider.gameObject.tag);
        if(collision.gameObject.CompareTag("Ground")) {
            playerIsOnTheGround = true;
        } 
        else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
