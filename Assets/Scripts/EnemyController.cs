using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    EnemyBase enemyActionsHandler;
    [SerializeField]EnemySO enemySO;
    int cachedHealthPoints;
    void Awake()
    {
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        cachedHealthPoints = enemySO.GetHealthPoints();
        sr.sprite = enemySO.GetEnemySprite();
        enemyActionsHandler = GetComponent<EnemyBase>();
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
        else
            enemyActionsHandler.Die();
    }

    private void OnApplicationQuit() 
    {
        enemySO.ResetEnemyHealthPoints(cachedHealthPoints);
    }
    private void OnDestroy() 
    {
        enemySO.ResetEnemyHealthPoints(cachedHealthPoints);
    }

    public EnemyBase GetEnemyBase() => enemyActionsHandler;
    public EnemySO GetEnemySO() => enemySO;
}
