using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] UIBar uIBar;
    [SerializeField] StatsSO playerStats;
    [SerializeField] float takeDamageCoolDownTime;

    float takeDamageTimer;
    Rigidbody2D playerRB;
    [SerializeField] bool isRagdoll = false;
    bool canJump = true;
    bool canTakeDamage = true;

    Vector3 left = new Vector3(1,0,0);
    //Vector3 down = new Vector3(0,-1,0);

    float hitboxDistance;
    Vector2 hitboxSize;
    float rateOfAttack;
    float attackCooldownCounter;
    int playerDamage;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        takeDamageTimer = 0;
        uIBar.SetMaxValue(playerStats.GetTotalHealthPoints()); 
        isRagdoll = false;
        playerDamage=1;
        hitboxDistance = 2;
        hitboxSize = new Vector2(2,3);
        rateOfAttack = 1;
        attackCooldownCounter=0;
    }

    void Update()
    {
        uIBar.SetMaxValue(playerStats.GetTotalHealthPoints());
        uIBar.SetCurrentValue(playerStats.GetCurrentHealthPoints());
        DamageCoolDownManager();
        MovementControl();
        playerStats.GetTotalInventoryWeight();
    }

    void DamageCoolDownManager()
    {
        if(takeDamageTimer >= takeDamageCoolDownTime)
            canTakeDamage = true; 
        else
            takeDamageTimer += Time.deltaTime;      
        Attack();
    }

    void MovementControl()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space) & canJump)
            Jump();
    }

    void Move()
    {
        if(!isRagdoll)
        {
            AdjustGameObjectDirectionToMovement();
            playerRB.velocity = new Vector2((Input.GetAxis("Horizontal") * left * playerStats.GetTotalMoveSpeedPoints() / playerStats.GetTotalInventoryWeight()).x, playerRB.velocity.y);
        }
    }

    void Jump()
    {
        canJump = false;
        playerRB.velocity = new Vector2(playerRB.velocity.x, playerStats.GetTotalJumpForcePoints() / playerStats.GetTotalInventoryWeight());
    }

    void AdjustGameObjectDirectionToMovement()
    {
        if(Input.GetKeyDown(KeyCode.D))
            transform.rotation = Quaternion.Euler(0,0,0);
        if(Input.GetKeyDown(KeyCode.A))
            transform.rotation = Quaternion.Euler(0,180,0);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        CheckJumpingAndRagdollCondition(other);
        if(other.gameObject.tag == "Enemy")
        {
            TakeDamage(other.gameObject.GetComponent<EnemyBase>().DealCollisionDamage());
            Collider2D enemyCollider = other.gameObject.GetComponent<Collider2D>();
            Collider2D playerCollider = GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(enemyCollider, playerCollider);
            IEnumerator coroutine = ResetCollision(playerCollider,enemyCollider);
            StartCoroutine(coroutine);
        }
    }

    private void CheckJumpingAndRagdollCondition(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "Ground")
        {
            canJump = true;
            isRagdoll = false;
        }
    }

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            if((damage - playerStats.GetTotalArmorPoints()) > 0)
                playerStats.SetCurrentHealthPoints(-(damage - playerStats.GetTotalArmorPoints()));
            canTakeDamage = false;
        }
    }

    IEnumerator ResetCollision(Collider2D pc, Collider2D ec)
    {
        yield return new WaitForSeconds(takeDamageCoolDownTime);
        Physics2D.IgnoreCollision(pc, ec, false);
    }
    
    public float GetPlayerWeight() => playerStats.GetTotalInventoryWeight();
    public void enableRagdoll() => isRagdoll = true;
    void Attack()
    {
        attackCooldownCounter+=Time.deltaTime;
        if(attackCooldownCounter<rateOfAttack)
            return;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 distanceVector = transform.rotation.y == 0 ? new Vector3(hitboxDistance,0,0) : new Vector3(-hitboxDistance,0,0);
            Vector2 hitboxPosition = transform.position + distanceVector;
            Collider2D[] itemsHit = Physics2D.OverlapBoxAll(hitboxPosition, hitboxSize,0);
            foreach(var item in itemsHit)
            {
                print(item.gameObject.name);
                HitItem(item);
            }
        }
    }

    void HitItem(Collider2D item)
    {
        EnemyController enemy = item.gameObject.GetComponent<EnemyController>();
        if(enemy!=null)
            //print("Ello mate");
            enemy.GetEnemyBase().GetHit(playerDamage, enemy.GetEnemySO());
    }
}