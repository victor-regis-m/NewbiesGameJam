using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Database/Create Enemy", order = 2)]
public class EnemySO : ScriptableObject
{
    [SerializeField] Sprite enemyImage;
    [SerializeField] float enemyDamage;
    [SerializeField] float enemyHealthPoints;
    [SerializeField] float moveSpeed;
    [SerializeField] float enemyRateOfAttack;

    public bool IsAlive() => enemyHealthPoints>0;
    public Sprite GetEnemySprite() => enemyImage;
    public float GetMoveSpeed() => moveSpeed;
    public float GetRateOfAttack() => enemyRateOfAttack;
    public float GetHealthPoints() => enemyHealthPoints;
    public void ResetEnemyHealthPoints(float hp) => enemyHealthPoints=hp;

    public void TakeDamage(float damage) => enemyHealthPoints -= damage;

}
