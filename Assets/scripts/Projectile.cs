using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int projectileSpeed = 400;
    public float projectileLifeTime = 5.0f;
    private Collider2D cl;
    private Rigidbody2D rb;
    //public Component Rigidbody2d;
    void Start()
    {
        cl = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        Shoot();
        
    }

    
    void Update()
    {

        DestroyProjectile();
        
    }

    void Shoot()
    {
        rb.AddForce(transform.forward * projectileSpeed);
    }

    void DestroyProjectile()
    {
        projectileLifeTime = projectileLifeTime - Time.deltaTime;

        if (projectileLifeTime <= 0)
        {
            Destroy(gameObject);
        }
     /*
        if (other.sTouching(cl))
        {
            DestroyProjectile(gameObject);
        }
          */    
    }

    
}
