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

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        takeDamageTimer = 0;
        uIBar.SetMaxValue(playerStats.GetTotalHealthPoints()); 
        isRagdoll = false;
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
}