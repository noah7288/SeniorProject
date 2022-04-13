using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject Player;
    private PlayerController playerScript;

    void Start()
    {
        GameStats.Instance.keyDropped = false;
        GameStats.Instance.keyPickedUp = false;
        playerScript = Player.GetComponent<PlayerController>();
        GameStats.Instance.spawnChance = Random.Range(1, 90);
    }

    
    void Update()
    {
        Death();
    }

    void Death()
    {
        if (GameStats.Instance.isAlive == false)
        {
            SceneManager.LoadScene("You Died");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" & GameStats.Instance.keyPickedUp == true)//change to key picked up bool
        {
            if (GameStats.Instance.Level == 10)
            {
                SceneManager.LoadScene("You Win");
            }
            else
            {
                GameStats.Instance.spawnCount = 0;
                GameStats.Instance.Level++;
                GameStats.Instance.overallDifficultyScore++;
                GameStats.Instance.spawnMax++;
                GameStats.Instance.PlayerHealth = playerScript.playerHealth;
                SceneManager.LoadScene("TileMaker");
                GameStats.Instance.spawnChance = Random.Range(1, 90);
            }
        }
    }
}
