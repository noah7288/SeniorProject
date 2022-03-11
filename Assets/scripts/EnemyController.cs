using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 5;
    //public int enemyDamage = 1;

    void Start()
    {
        
    }


    void Update()
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D PlayerProjectile)
    {
        enemyHealth = enemyHealth - 1;//replace 1 with player damage variable

    }

    void Death()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
