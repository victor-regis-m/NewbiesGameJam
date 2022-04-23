using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour, IEnemyActions
{
    float initialTime;
    float moveSpeed;
    Vector3 initialPosition;
    void Start()
    {
        initialTime = Time.time;
        initialPosition = transform.position;
    }
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void GetHit()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        float timeDelta = Time.time - initialTime;
        float ypos = -0.75f*Mathf.Sin(timeDelta/1.5f)*moveSpeed;
        float xpos = -(timeDelta)*moveSpeed;
        transform.position = new Vector3(xpos, ypos, 0) + initialPosition;
    }

    public void ParseMoveSpeed(float ms) => moveSpeed = ms;

    public void ParseRateOfAttack(float rate)
    {
    }
}
