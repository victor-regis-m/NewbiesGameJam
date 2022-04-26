using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Database/Create Enemy", order = 2)]
public class EnemySO : ScriptableObject
{
    [SerializeField] Sprite enemyImage;
    [SerializeField] int enemyDamage;
    [SerializeField] int enemyHealthPoints;
    [SerializeField] float moveSpeed;
    [SerializeField] float enemyRateOfAttack;

    public bool IsAlive() => enemyHealthPoints>0;
    public Sprite GetEnemySprite() => enemyImage;
    public float GetMoveSpeed() => moveSpeed;
    public float GetRateOfAttack() => enemyRateOfAttack;
    public int GetHealthPoints()=>enemyHealthPoints;
    public void ResetEnemyHealthPoints(int hp)=>enemyHealthPoints=hp;

    public void TakeDamage(int damage) => enemyHealthPoints-=damage;

}
