using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Database/Create Enemy", order = 0)]
public class EnemySO : ScriptableObject
{
    [SerializeField] Sprite enemyImage;
    [SerializeField] int enemyDamage;
    [SerializeField] int healthPoints;
    [SerializeField] float moveSpeed;
    [SerializeField] float rateOfAttack;

    public bool IsAlive() => healthPoints>0;
    public Sprite GetEnemySprite() => enemyImage;
    public float GetMoveSpeed() => moveSpeed;

    public float GetRateOfAttack() => rateOfAttack;
}
