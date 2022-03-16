using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    //public int projectileSpeed = 400;
    public float projectileLifeTime = 5.0f;
    private Collider2D cl;
    private Rigidbody2D rb;

    //public Component Rigidbody2d;
    void Start()
    {
        cl = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();


    }


    void Update()
    {

        DestroyProjectile();



    }

    void FixedUpdate()
    {

    }



    void DestroyProjectile()
    {
        projectileLifeTime = projectileLifeTime - Time.deltaTime;

        if (projectileLifeTime <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
            Destroy(gameObject);
        
    }

}
