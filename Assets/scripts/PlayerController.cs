using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public Transform gunEnd;
    public float projectileSpeed = 10f;
    public GameObject playerMelee;

    private float meleeTime = 0.5f;

    public bool IsAlive = true;

    private float fireRate = 0.3f;
    private float fireRateMax = 0.2f;

    public float shootCooldown = 10;

    public float moveSpeed = 10.0f;

    //public int playerDamage = 1;

    public int playerHealth;
    public int playerHealthMax = 15;

    public bool damageBoosted;

    

    void Start()
    {
        damageBoosted = false;//removes damage boost at the end of a stage
        playerHealth = GameStats.Instance.PlayerHealth;//sets player health to gamestats health
        GameStats.Instance.isAlive = true;//sets player to alive
        playerMelee.SetActive(false);
        GameStats.Instance.playerDamage = 1;//resets player damage from damage boost
    }

    void Update()
    {
        PlayerSave();//loads player health into gamestats
        Controls();
        if (Input.GetButton("Fire1") & shootCooldown >= 1 & fireRate >= fireRateMax)
        {
            Shoot();
        }
        Death();
        if (Input.GetButtonDown("Fire2"))//melee
        {
            Melee();
        }
        if(meleeTime <= 0.0f)
        {
            playerMelee.SetActive(false);
        }
        if (meleeTime >= 0)
        {
            meleeTime = meleeTime - Time.deltaTime;
        }
        
    }

    void FixedUpdate()
    {
         ShootTime();//frames don't affect gun charge
    }

    public void PlayerSave()
    {
        GameStats.Instance.PlayerHealth = playerHealth;
    }

    void Controls() //moves character
        {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        //track mouse
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    } 

    void Melee()//player melee
    {
        meleeTime = 0.5f;
        playerMelee.SetActive(true);
    }

    void Shoot()//fires projectile
    {
        
        GameObject bullet = Instantiate(projectile, gunEnd.position, gunEnd.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunEnd.up * projectileSpeed, ForceMode2D.Impulse);
        shootCooldown = shootCooldown - 1;
        fireRate = 0;

    }

    void ShootTime()//gun charge level. can't shoot when < 1
    {
        if (shootCooldown <= 10)
        {
            shootCooldown = shootCooldown + Time.deltaTime * 2;
        }
        if(fireRate <= fireRateMax)
        {
            fireRate = fireRate + Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Powerup")//damage boost
        {
            GameStats.Instance.score = GameStats.Instance.score + (15 * (GameStats.Instance.overallDifficultyScore / 2));
            if (damageBoosted == false)
            {
                GameStats.Instance.playerDamage++;
                damageBoosted = true;
                if(GameStats.Instance.playerDamage >= 3)//damage can't go over 3
                {
                    GameStats.Instance.playerDamage = 3;
                }
            }
        }
        if(other.gameObject.tag == "EnemyProjectile")//damage player
        {
            playerHealth = playerHealth - 1;//change 1 to enemy damage variable
            GameStats.Instance.RangerLFEScore++;
            GameStats.Instance.difficultyDecreaseHit++;

        }
        if (other.gameObject.tag == "EnemyMelee")//damage player melee
        {
            playerHealth = playerHealth - 2;
            GameStats.Instance.SlicerLFEScore++;
            GameStats.Instance.difficultyDecreaseHit++;
        }
        if (other.gameObject.tag == "PowerupHealth")//restore health
        {
            GameStats.Instance.score = GameStats.Instance.score + (10 * (GameStats.Instance.overallDifficultyScore/2));
            playerHealth = playerHealth + 10;
            if(playerHealth >= playerHealthMax+1)
            {
                playerHealth = playerHealthMax;
                
            }
        }
        if (other.gameObject.tag == "PowerupAmmo")//restores amount of ammo
        {
            GameStats.Instance.score = GameStats.Instance.score + (5 * (GameStats.Instance.overallDifficultyScore / 2));
            shootCooldown = shootCooldown + 4.0f;//change to ammo restore variable
            if(shootCooldown >= 10)
            {
                shootCooldown = 10;
            }
        }
        if (other.gameObject.tag == "Key")//aquires key
        {
            GameStats.Instance.keyPickedUp = true;
        }
        if(other.gameObject.tag == "Trap")//step in trap
        {
            playerHealth = playerHealth - 4;
            GameStats.Instance.difficultyDecreaseHit++;
        }
        }

    void Death()//player dies and sets isalive to false loading the fail screen
    {
        if(playerHealth <= 0)
        {
            GameStats.Instance.isAlive = false;
            
        }
    }
}
