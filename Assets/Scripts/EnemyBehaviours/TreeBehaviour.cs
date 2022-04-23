using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour, IEnemyActions
{
    [SerializeField]Sprite projectile;
    float attackTimeCounter;
    float rateOfAttack;
    public void Attack()
    {
        attackTimeCounter+=Time.deltaTime;
        if(attackTimeCounter >= rateOfAttack)
        {

        }
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
        throw new System.NotImplementedException();
    }

    public void ParseMoveSpeed(float ms)
    {
    }
    
    public void ParseRateOfAttack(float rate) => rateOfAttack = rate;

    // Start is called before the first frame update
    void Start()
    {
        attackTimeCounter=0;
    }


}
