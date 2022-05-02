using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : EnemyBase
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip explosion;
    float waitTime;
    bool startExplosion;
    float timeCounter;
    GameObject player;
    bool playerIsInRadius;
    float explosionForce;
    float explosionDamage;
    
    override public void Attack()
    {
        if(!startExplosion)
            return;
        timeCounter+=Time.deltaTime;
        if(timeCounter<waitTime)
            return;
        if(playerIsInRadius)
        {
            Vector3 direction = (player.transform.position-transform.position).normalized;
            PlayerController pc = player.GetComponent<PlayerController>();
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x, direction.y)*explosionForce/pc.GetPlayerWeight());
            pc.enableRagdoll();
            pc.TakeDamage(explosionDamage);
            audioSource.PlayOneShot(explosion);
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 2.5f;
        startExplosion=false;
        player = null;
        playerIsInRadius=false;
        explosionForce= 5000;
        collisionDamage = 1;
        explosionDamage = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.GetComponent<PlayerController>()!=null)
        {
            if(player==null)
                player = other.gameObject;
            startExplosion=true;
            playerIsInRadius=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.GetComponent<PlayerController>()!=null)
            playerIsInRadius=false;
    }
}
