using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 4;
    //public int enemyDamage = 1;

    private int drop;
    public GameObject droppedItem;
    public GameObject droppedItem2;
    public GameObject droppedItem3;

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
            drop = Random.Range(0, 10);
            if(drop <= 2)
            {
                Instantiate(droppedItem, transform.position, droppedItem.transform.rotation);
            }
            else if(drop >= 9)
            {
                Instantiate(droppedItem2, transform.position, droppedItem.transform.rotation);
            }
            else
            {
                Instantiate(droppedItem3, transform.position, droppedItem.transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }
}
