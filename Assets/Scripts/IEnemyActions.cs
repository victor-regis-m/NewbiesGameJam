using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyActions 
{
    void Move();
    void Attack();
    void GetHit();
    void Die();
    void ParseMoveSpeed(float ms);
    void ParseRateOfAttack(float rate);
}

public enum AttackType
{
    Linear, Parabolic
}

public enum StartingMovingDirection
{
    Left, Right
}
