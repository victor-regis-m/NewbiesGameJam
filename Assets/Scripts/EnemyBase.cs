using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour 
{
    public virtual void Move(){}
    public virtual void Attack(){}
    public virtual void GetHit(){}
    public virtual void Die(){}
    public virtual void ParseMoveSpeed(float ms){}
    public virtual void ParseRateOfAttack(float rate){}
    public virtual float DealCollisionDamage(){return 0;}
}

public enum AttackType
{
    Linear, Parabolic
}

public enum StartingMovingDirection
{
    Left, Right
}
