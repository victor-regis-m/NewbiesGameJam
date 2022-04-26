using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour 
{
    internal float collisionDamage;
    internal float moveSpeed;
    public virtual void Move(){}
    public virtual void Attack(){}
    public virtual void GetHit(int damage, EnemySO enemySO){enemySO.TakeDamage(damage);}
    public virtual void Die(){Destroy(gameObject);}
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
