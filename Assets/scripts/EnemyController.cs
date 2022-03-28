using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 4;
    //public int enemyDamage = 1;

    private int drop;
    public GameObject droppedItem;
    public GameObject droppedItem2;
    public GameObject droppedItem3;

    public Transform player;
    private Rigidbody2D rb;

    

    public GameObject Player;
    private PlayerController playerScript;

    public Transform gun;
    public GameObject projectile;
    public float projectileSpeed = 10;

    private float shootTimer;



    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        
    }

    

    void Update()
    {
        Move();
        Death();

        
            Shoot();
        
    }

    void FixedUpdate()
    {
        
    }

    


    void Move()
    {
        
        
    }

    
    void Shoot()
    {

        if (shootTimer <= 0)
        {
            GameObject bullet = Instantiate(projectile, gun.position, gun.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(gun.up * projectileSpeed, ForceMode2D.Impulse);
            shootTimer = Random.Range(1, 3);
        }
        shootTimer = shootTimer - Time.deltaTime;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerProjectile") { 
            enemyHealth = enemyHealth - playerScript.playerDamage;
    }
        if (other.gameObject.tag == "PlayerMelee")
        {
            enemyHealth = enemyHealth - (playerScript.playerDamage*2);
        }
    }

    void Death()
    {
        if (enemyHealth <= 0)
        {
            drop = Random.Range(0, 10);
            if(drop <= 1)
            {
                Instantiate(droppedItem, transform.position, droppedItem.transform.rotation);
            }
            else if(drop >= 9)
            {
                Instantiate(droppedItem2, transform.position, droppedItem.transform.rotation);
            }
            else if(drop >= 3 & drop <= 7)
            {
                Instantiate(droppedItem3, transform.position, droppedItem.transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }
}
