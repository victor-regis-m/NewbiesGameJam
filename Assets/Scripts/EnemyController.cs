using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyBase enemyActionsHandler;
    [SerializeField]EnemySO enemySO;
    void Awake()
    {
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        sr.sprite = enemySO.GetEnemySprite();
        enemyActionsHandler = GetComponent<EnemyBase>();
        enemyActionsHandler.ParseMoveSpeed(enemySO.GetMoveSpeed());
        enemyActionsHandler.ParseRateOfAttack(enemySO.GetRateOfAttack());
        enemyActionsHandler.ParseHealthPoints(enemySO.GetHealthPoints());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        if(enemyActionsHandler.IsAlive())
            enemyActionsHandler.Move();
    }

    void Attack()
    {
        if(enemyActionsHandler.IsAlive())
            enemyActionsHandler.Attack();
        else
            enemyActionsHandler.Die();
    }

    public EnemyBase GetEnemyBase() => enemyActionsHandler;
    public EnemySO GetEnemySO() => enemySO;
}
