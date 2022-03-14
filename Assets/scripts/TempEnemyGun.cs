using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemyGun : MonoBehaviour
{

    public Transform gun;
    public GameObject projectile;
    public float projectileSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
                
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(projectile, gun.position, gun.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gun.up * projectileSpeed, ForceMode2D.Impulse);
    }
}
