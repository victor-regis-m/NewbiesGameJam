using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    AttackType _attackType;
    Vector3 _direction;
    float _startTime;
    Vector3 _startPos;
    float g = 3;
    float moveSpeed = 7;

    public void InitializeProjectileController(AttackType attackType, Vector3 direction)
    {
        _attackType = attackType;
        _direction = direction.normalized;
        _startTime = Time.time;
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       switch(_attackType)
       {
           case AttackType.Linear:
            transform.position = _startPos + moveSpeed*(Time.time-_startTime)*_direction;
           break;

           case AttackType.Parabolic:
            Vector3 gravity = new Vector3(0,-1,0)*g;
            transform.position = _startPos + moveSpeed*(Time.time-_startTime)*_direction + gravity*(Time.time-_startTime)*(Time.time-_startTime);
           break;
       } 
    }
}
