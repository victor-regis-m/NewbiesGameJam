using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour 
{
    internal float collisionDamage;
    public virtual void Move(){}
    public virtual void Attack(){}
    public virtual void GetHit(){}
    public virtual void Die(){}
    public virtual void ParseMoveSpeed(float ms){}
    public virtual void ParseRateOfAttack(float rate){}
    public virtual float DealCollisionDamage(){return collisionDamage;}
}

public enum AttackType
{
    Linear, Parabolic
}

public enum StartingMovingDirection
{
    Left, Right
}
