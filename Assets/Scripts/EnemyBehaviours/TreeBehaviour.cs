using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : EnemyBase
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip takeDamage;
    [SerializeField] AudioClip dead;
    [SerializeField] Sprite projectileSprite;
    [SerializeField] AttackType attackType;
    float attackTimeCounter;
    float rateOfAttack;
    override public void Attack()
    {
        attackTimeCounter+=Time.deltaTime;
        if(attackTimeCounter >= rateOfAttack)
        {
            attackTimeCounter=0;
            GameObject projectile = new GameObject("Projectile");
            projectile.transform.position = transform.position;
            SpriteRenderer sr = projectile.AddComponent<SpriteRenderer>() as SpriteRenderer;
            sr.sprite = projectileSprite;
            ProjectileController pc = projectile.AddComponent<ProjectileController>() as ProjectileController;
            Vector3 direction = attackType== AttackType.Parabolic? new Vector3(-1,1,0): new Vector3(-1,0,0);
            pc.InitializeProjectileController(attackType, direction);
            audioSource.PlayOneShot(shoot);
        }
    }

    override public void GetHit(float damage)
    {
        healthPoints -= damage;
        audioSource.PlayOneShot(takeDamage);
    }

    override public void Die()
    {
        audioSource.PlayOneShot(dead);
        Destroy(gameObject);
    }

    override public void ParseRateOfAttack(float rate) => rateOfAttack = rate;

    // Start is called before the first frame update
    void Start()
    {
        attackTimeCounter=0;
    }


}
