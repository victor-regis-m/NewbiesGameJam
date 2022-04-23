using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerRB;
    [SerializeField][Range(0,500)]float playerSpeed = 240;
    [SerializeField][Range(0,300)]float playerWeight = 80;
    [SerializeField][Range(0,1500)]float jumpForce = 300;
    bool canJummp;

    Vector3 left = new Vector3(1,0,0);
    Vector3 down = new Vector3(0,-1,0);

    void Start()
    {
        player = gameObject;
        playerRB = GetComponent<Rigidbody2D>();
        canJummp = true;
    }

    void Update()
    {
        MovementControl();
    }

    void MovementControl()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space) & canJummp)
            Jump();
    }

    void Move()
    {
        gameObject.transform.position +=  Input.GetAxis("Horizontal")*left*playerSpeed*Time.deltaTime/playerWeight;
    }

    void Jump()
    {
        canJummp=false;
        playerRB.velocity = -jumpForce/playerWeight*down;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        CheckJumpingCondition(other);
    }

    private void CheckJumpingCondition(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "Ground")
            canJummp = true;
    }
}