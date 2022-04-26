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
    public Sprite GetEnemySprite() => enemyImage;
    public float GetMoveSpeed() => moveSpeed;
    public float GetRateOfAttack() => enemyRateOfAttack;
    public float GetHealthPoints() => enemyHealthPoints;
}
