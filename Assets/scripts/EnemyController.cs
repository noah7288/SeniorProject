using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 4;
    //public int enemyDamage = 1;

    public GameObject Player;
    private PlayerController playerScript;

    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
    }


    void Update()
    {
        Death();
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
            Destroy(gameObject);
        }
    }
}
