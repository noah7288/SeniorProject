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

    public int playerDamage = 1;

    public int playerHealth = 15;
    public int playerHealthMax = 15;


    void start()
    {
        IsAlive = true;
        playerMelee.SetActive(false);
    }

    void Update()
    {
        Controls();
        if (Input.GetButton("Fire1") & shootCooldown >= 1 & fireRate >= fireRateMax)
        {
            Shoot();
        }
        Death();
        if (Input.GetButtonDown("Fire2"))
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
         ShootTime();
    }

    void Controls() 
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

    void Melee()
    {
        meleeTime = 0.5f;
        playerMelee.SetActive(true);
    }

    void Shoot()
    {
        
        GameObject bullet = Instantiate(projectile, gunEnd.position, gunEnd.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunEnd.up * projectileSpeed, ForceMode2D.Impulse);
        shootCooldown = shootCooldown - 1;
        fireRate = 0;

    }

    void ShootTime()
    {
        if (shootCooldown <= 10)
        {
            shootCooldown = shootCooldown + Time.deltaTime;
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
            playerDamage++;
        }
        if(other.gameObject.tag == "EnemyProjectile")//damage player
        {
            playerHealth = playerHealth - 1;//change 1 to enemy damage variable
        }
        if (other.gameObject.tag == "PowerupHealth")//restore health
        {
            playerHealth = playerHealth + 10;
            if(playerHealth >= playerHealthMax+1)
            {
                playerHealth = playerHealthMax;
            }
        }
        if (other.gameObject.tag == "PowerupAmmo")//restores amount of ammo
        {
            shootCooldown = shootCooldown + 3.0f;//change to ammo restore variable
        }
    }

    void Death()
    {
        if(playerHealth <= 0)
        {
            IsAlive = false;
            
        }
    }
}
