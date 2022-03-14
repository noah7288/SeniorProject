using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public Transform gunEnd;
    public float projectileSpeed = 10f;

    public bool IsAlive;

    public float shootCooldown = 10;

    public float moveSpeed = 10.0f;

    public int playerDamage = 1;

    public int playerHealth = 15;


    void start()
    {
        IsAlive = true;
    }

    void Update()
    {
        Controls();
        if (Input.GetButtonDown("Fire1") & shootCooldown >= 1)
        {
            Shoot();
        }
        Death();
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

    void Shoot()
    {
        
        GameObject bullet = Instantiate(projectile, gunEnd.position, gunEnd.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunEnd.up * projectileSpeed, ForceMode2D.Impulse);
        shootCooldown = shootCooldown - 1;
    }

    void ShootTime()
    {
        if (shootCooldown <= 10)
        {
            shootCooldown = shootCooldown + Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Powerup")
        {
            playerDamage++;
        }
        if(other.gameObject.tag == "EnemyProjectile")
        {
            playerHealth = playerHealth - 1;//change 1 to enemy damage variable
        }
    }

    void Death()
    {
        if(playerHealth <= 0)
        {
            IsAlive = false;
            Destroy(gameObject);
        }
    }
}
