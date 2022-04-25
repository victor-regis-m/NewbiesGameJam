using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : EnemyBase
{
    float initialTime;
    float moveSpeed;
    Vector3 initialPosition;
    void Start()
    {
        initialTime = Time.time;
        initialPosition = transform.position;
    }

    override public void Move()
    {
        float timeDelta = Time.time - initialTime;
        float ypos = -0.75f*Mathf.Sin(timeDelta/1.5f)*moveSpeed;
        float xpos = -(timeDelta)*moveSpeed;
        transform.position = new Vector3(xpos, ypos, 0) + initialPosition;
    }

    override public void ParseMoveSpeed(float ms) => moveSpeed = ms;
}
