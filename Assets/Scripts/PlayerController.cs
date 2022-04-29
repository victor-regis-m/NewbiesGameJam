using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip attackSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip jumpLandSFX;
    [SerializeField] AudioClip stepSFX;
    [SerializeField] AudioClip takeDamageSFX;


    [Header("Other Variables")]
    [SerializeField] UIBar uIBar;
    [SerializeField] StatsSO playerStats;
    [SerializeField] float takeDamageCoolDownTime;
    [SerializeField] HealthBarController healthBarController;

    float takeDamageTimer;
    Rigidbody2D playerRB;
    

    [SerializeField] bool isRagdoll = false;
    [SerializeField] bool canJump = true;
    bool canTakeDamage = true;

    Vector3 left = new Vector3(1,0,0);
    float rateOfAttack;
    float attackCooldownCounter;
    Vector2 footColliderOffset;
    Vector2 footColliderSize;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        takeDamageTimer = 0;
        uIBar.SetMaxValue(playerStats.GetTotalHealthPoints());
        isRagdoll = false;
        rateOfAttack = 1;
        attackCooldownCounter = 0;
        footColliderOffset = new Vector2(0,-1.5f);
        footColliderSize = new Vector2(1, 0.1f);
    }

    void Update()
    {
        uIBar.SetMaxValue(playerStats.GetTotalHealthPoints());
        uIBar.SetCurrentValue(playerStats.GetCurrentHealthPoints());
        healthBarController.SetMaxValue(playerStats.GetTotalHealthPoints());
        healthBarController.SetCurrentValue(playerStats.GetCurrentHealthPoints());
        DamageCoolDownManager();
        CheckJumpingAndRagdollCondition();
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
            audioSource.PlayOneShot(stepSFX);
        }
    }

    void Jump()
    {
        canJump = false;
        playerRB.velocity = new Vector2(playerRB.velocity.x, playerStats.GetTotalJumpForcePoints() / playerStats.GetTotalInventoryWeight());
        audioSource.PlayOneShot(jumpSFX);
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


    private void CheckJumpingAndRagdollCondition()
    {
        Vector2 position = transform.position;
        var objectsOverlaping = Physics2D.OverlapBoxAll(position + footColliderOffset, footColliderSize, 0);
        foreach(var other in objectsOverlaping)
        {
            GameObject otherObject = other.gameObject;
            if(otherObject.tag == "Ground" & (!canJump | isRagdoll) & playerRB.velocity.y<=0)
            {
                canJump = true;
                isRagdoll = false;
                audioSource.PlayOneShot(jumpLandSFX);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            if((damage - playerStats.GetTotalArmorPoints()) > 0)
            {
                playerStats.SetCurrentHealthPoints(-(damage - playerStats.GetTotalArmorPoints()));
                audioSource.PlayOneShot(takeDamageSFX);
            }    
            canTakeDamage = false;
        }
    }

    IEnumerator ResetCollision(Collider2D pc, Collider2D ec)
    {
        yield return new WaitForSeconds(takeDamageCoolDownTime);
        if(ec!=null)
            Physics2D.IgnoreCollision(pc, ec, false);
    }
    
    public float GetPlayerWeight() => playerStats.GetTotalInventoryWeight();
    public void enableRagdoll() => isRagdoll = true;
    void Attack()
    {
        attackCooldownCounter += Time.deltaTime;
        if(attackCooldownCounter < rateOfAttack)
            return;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Collider2D[] itemsHit = Physics2D.OverlapCircleAll(transform.position, playerStats.GetTotalRangePoints());
            foreach(var item in itemsHit)
            {
                if(IsOnAttckingSide(item))
                {
                    HitItem(item);
                    audioSource.PlayOneShot(attackSFX);
                }
                    
            }
        }
    }

    void HitItem(Collider2D item)
    {
        EnemyController enemy = item.gameObject.GetComponent<EnemyController>();
        if(enemy != null)
            enemy.GetEnemyBase().GetHit(playerStats.GetTotalDamagePoints());   
    }

    bool IsOnAttckingSide(Collider2D enemy)
    {
        bool isPlayerFacingRight = transform.rotation.y==0;
        bool isEnemyToPlayerRight = transform.position.x<=enemy.transform.position.x;
        return (!isPlayerFacingRight&!isEnemyToPlayerRight)|(isPlayerFacingRight&isEnemyToPlayerRight);
    }
    
}