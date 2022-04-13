using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public GameObject Player;
    private PlayerController playerScript;

    void Start()
    {
        GameStats.Instance.Level = 1;
        playerScript = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void Death()
    {
        if(playerScript.IsAlive == false)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("You Died");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameStats.Instance.Level++;
            GameStats.Instance.PlayerHealth = playerScript.playerHealth;
            SceneManager.LoadScene("TileMaker");

        }
    }
}
