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
    public GameObject droppedItem3;//ammo

    public GameObject key;

    private Transform player;
    private Rigidbody2D rb;

    

    public GameObject Player;
    private PlayerController playerScript;

    public Transform gun;
    public GameObject projectile;
    public float projectileSpeed = 15;

    private float shootTimer;

    

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemyHealth = 4 + (GameStats.Instance.overallDifficultyScore / 2);
        playerScript = Player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();


        gameObject.GetComponent<AIDestinationSetter>().target = player;
    }

    

    void Update()
    {
        Death();
        Shoot();
        
    }

    

    
    void Shoot()
    {

        if (shootTimer <= 0)
        {
            GameObject bullet = Instantiate(projectile, gun.position, gun.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            //rb.AddForce(gun.up * projectileSpeed, ForceMode2D.Impulse);
            shootTimer = Random.Range(1, 3);
        }
        shootTimer = shootTimer - Time.deltaTime;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerProjectile") { 
            enemyHealth = enemyHealth - GameStats.Instance.playerDamage;
    }
        if (other.gameObject.tag == "PlayerMelee")
        {
            enemyHealth = enemyHealth - (GameStats.Instance.playerDamage*2);
        }
    }

    void Death()
    {
        if (enemyHealth <= 0)
        {
            drop = Random.Range(0, 100);
            if(drop <= 8)
            {
                Instantiate(droppedItem, transform.position, droppedItem.transform.rotation);
            }
            else if(drop >= 95)
            {
                Instantiate(droppedItem2, transform.position, droppedItem.transform.rotation);
            }
            else if(drop >= 60 & drop <= 80)
            {
                Instantiate(droppedItem3, transform.position, droppedItem.transform.rotation);
            }
            else if(drop >= 50 & drop <= 59 & GameStats.Instance.keyDropped == false)
            {
                Instantiate(key, transform.position, droppedItem.transform.rotation);
                GameStats.Instance.keyDropped = true;
            }
            if(GameStats.Instance.spawnCount == 1 & GameStats.Instance.keyDropped == false)
            {
                Instantiate(key, transform.position, droppedItem.transform.rotation);
                GameStats.Instance.keyDropped = true;
            }
            GameStats.Instance.spawnCount = GameStats.Instance.spawnCount - 1;
            GameStats.Instance.enemiesDefeated++;
            GameStats.Instance.score = GameStats.Instance.score + (10 * (GameStats.Instance.overallDifficultyScore / 2));
            Destroy(gameObject);
        }
    }
}
