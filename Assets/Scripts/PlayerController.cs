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
    }

    void Update()
    {
        uiBar.SetCurrentValue(playerHitPoints);
        DamageCoolDownManager();
        MovementControl();
        UpdateTotalWeight();
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
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
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

}