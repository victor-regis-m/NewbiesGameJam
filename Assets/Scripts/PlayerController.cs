using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerRB;
    [SerializeField][Range(0,500)]float playerSpeed = 240;
    [SerializeField][Range(0,300)]float playerWeight = 80;
    [SerializeField][Range(0,1500)]float jumpForce = 300;
    [SerializeField] UIBar uiBar;
    bool canJump;

    Vector3 left = new Vector3(1,0,0);
    Vector3 down = new Vector3(0,-1,0);

    [SerializeField]float playerHitPoints;
    int playerMaxHitPoints;
    float takeDamageCoolDownTime;
    float takeDamageTimer;
    bool canTakeDamage;
    static float inventoryWeight;
    float playerTotalWeight;
    [SerializeField]bool isRagdoll;

    float hitboxDistance;
    Vector2 hitboxSize;
    float rateOfAttack;
    float attackCooldownCounter;
    int playerDamage;

    void Start()
    {
        player = gameObject;
        playerRB = GetComponent<Rigidbody2D>();
        canJump = true;
        takeDamageCoolDownTime = 3;
        takeDamageTimer = 0;
        canTakeDamage=true;
        playerMaxHitPoints = 100;
        playerHitPoints = playerMaxHitPoints;
        UpdateTotalWeight();
        uiBar.SetMaxValue(playerMaxHitPoints);
        isRagdoll=false;
        playerDamage=1;
        hitboxDistance = 2;
        hitboxSize = new Vector2(2,3);
        rateOfAttack = 1;
        attackCooldownCounter=0;
    }

    void Update()
    {
        uiBar.SetCurrentValue(playerHitPoints);
        DamageCoolDownManager();
        MovementControl();
        UpdateTotalWeight();
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
            playerRB.velocity = new Vector2((Input.GetAxis("Horizontal")*left*playerSpeed/playerTotalWeight).x, playerRB.velocity.y);
        }
    }

    void AdjustGameObjectDirectionToMovement()
    {
        if(Input.GetKeyDown(KeyCode.D))
            transform.rotation = Quaternion.Euler(0,0,0);
        if(Input.GetKeyDown(KeyCode.A))
            transform.rotation = Quaternion.Euler(0,180,0);
    }

    void Jump()
    {
        canJump=false;
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce/playerTotalWeight);
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

    IEnumerator ResetCollision(Collider2D pc, Collider2D oc)
    {
        yield return new WaitForSeconds(takeDamageCoolDownTime);
        Physics2D.IgnoreCollision(oc, pc, false);
    }

    private void CheckJumpingAndRagdollCondition(Collision2D other)
    {
        GameObject otherObject = other.gameObject;
        if(otherObject.tag == "Ground")
        {
            canJump = true;
            isRagdoll=false;
        }
    }

    public float GetPlayerWeight() => playerTotalWeight;

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            playerHitPoints-=damage;
            canTakeDamage = false;
        }
    }
    
    void DamageCoolDownManager()
    {
        if(takeDamageTimer>=takeDamageCoolDownTime)
            canTakeDamage=true;
        else
            takeDamageTimer+=Time.deltaTime;
    }

    public static void UpdateInventoryWeight(float weight)
    {
        inventoryWeight = weight;
    }

    void UpdateTotalWeight()
    {
        playerTotalWeight = playerWeight + inventoryWeight;
    }

    public void enableRagdoll() => isRagdoll =true;

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