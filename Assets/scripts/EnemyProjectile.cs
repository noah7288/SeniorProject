using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public int projectileSpeed = 15;
    public float projectileLifeTime = 8.0f;
    private Collider2D cl;
    private Rigidbody2D rb;

    public Transform player;

    

    //public Component Rigidbody2d;
    void Start()
    {
        cl = gameObject.GetComponent<CircleCollider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        Vector2 direction = (player.transform.position - transform.position).normalized * projectileSpeed;
        rb.velocity = new Vector2(direction.x, direction.y);


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
        if (other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
        
    }

}
