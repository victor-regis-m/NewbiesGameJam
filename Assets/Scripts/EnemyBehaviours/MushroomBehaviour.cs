using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehaviour : EnemyBase
{
    float waitTime;
    float moveTime;
    float moveCounter;
    [SerializeField] StartingMovingDirection startingMovingDirection;
    Vector3 movingDirection;

    override public void Move()
    {
        moveCounter+=Time.deltaTime;
        if(moveCounter<=moveTime)
            transform.position+=movingDirection*moveSpeed*Time.deltaTime;
        else if(moveCounter<=moveTime + waitTime)
        {}
        else
        {
            movingDirection=-movingDirection;
            moveCounter=0;
        }
    }

    override public void ParseMoveSpeed(float ms) => moveSpeed=ms;

    // Start is called before the first frame update
    void Start()
    {
        moveCounter=0;
        waitTime=1.5f;
        moveTime=3;
        movingDirection = startingMovingDirection==StartingMovingDirection.Left ? new Vector3(-1,0,0) : new Vector3(1,0,0); 
        collisionDamage = 10;
    }

}
