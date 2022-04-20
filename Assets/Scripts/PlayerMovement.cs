using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerRB;
    [SerializeField][Range(0,300)]float playerSpeed = 140;
    [SerializeField][Range(0,200)]float playerWeight = 70;
    [SerializeField][Range(0,1000)]float jumpForce = 300;
    bool canJummp;

    Vector3 left = new Vector3(1,0,0);
    Vector3 down = new Vector3(0,-1,0);
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        playerRB = GetComponent<Rigidbody2D>();
        canJummp = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovementControl();
    }

    void MovementControl()
    {
        gameObject.transform.position +=  Input.GetAxis("Horizontal")*left*playerSpeed*Time.deltaTime/playerWeight;
        if(Input.GetKeyDown(KeyCode.Space) & canJummp)
        {
            canJummp=false;
            playerRB.velocity = -jumpForce/playerWeight*down;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "Ground")
            canJummp = true;
    }
}
