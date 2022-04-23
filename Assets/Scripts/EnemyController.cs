using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    IEnemyActions enemyActionsHandler;
    [SerializeField]EnemySO enemySO;
    void Awake()
    {
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sr.sprite = enemySO.GetEnemySprite();
        enemyActionsHandler = GetComponent<IEnemyActions>();
        enemyActionsHandler.ParseMoveSpeed(enemySO.GetMoveSpeed());
        enemyActionsHandler.ParseRateOfAttack(enemySO.GetRateOfAttack());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        if(enemySO.IsAlive())
            enemyActionsHandler.Move();
    }

    void Attack()
    {
        if(enemySO.IsAlive())
            enemyActionsHandler.Attack();
    }

    
}
