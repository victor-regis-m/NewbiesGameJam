using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour 
{
    internal float collisionDamage;
    internal float moveSpeed;
    [SerializeField]internal float healthPoints;
    public virtual void Move(){}
    public virtual void Attack(){}
    public virtual void GetHit(float damage)=>healthPoints-=damage;
    public virtual void Die()=>Destroy(gameObject);
    public virtual void ParseMoveSpeed(float ms){}
    public virtual void ParseRateOfAttack(float rate){}
    public virtual void ParseHealthPoints(float hp) => healthPoints=hp;
    public virtual float DealCollisionDamage() => collisionDamage;
    public virtual bool IsAlive()=>healthPoints>0;
    
}

public enum AttackType
{
    Linear, Parabolic
}

public enum StartingMovingDirection
{
    Left, Right
}
