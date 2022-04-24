using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour, IEnemyActions
{
    float waitTime;
    bool startExplosion;
    float timeCounter;
    GameObject player;
    bool playerIsInRadius;
    float explosionForce = 400;
    
    public void Attack()
    {
        if(!startExplosion)
            return;
        timeCounter+=Time.deltaTime;
        if(timeCounter<waitTime)
            return;
        if(playerIsInRadius)
        {
            Vector3 direction = (player.transform.position-transform.position).normalized;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y)*explosionForce/player.GetComponent<PlayerMovement>().GetPlayerWeight();
        }
        Destroy(gameObject);
    }

    public void Die()
    {
    }

    public void GetHit()
    {
    }

    public void Move()
    {
    }

    public void ParseMoveSpeed(float ms)
    {
    }

    public void ParseRateOfAttack(float rate)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 2;
        startExplosion=false;
        player = null;
        playerIsInRadius=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.GetComponent<PlayerMovement>()!=null)
        {
            if(player==null)
                player = other.gameObject;
            startExplosion=true;
            playerIsInRadius=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        playerIsInRadius=false;
    }
}
