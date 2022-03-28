using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject Player;
    private PlayerController playerScript;

    void Start()
    {
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("You Win");
        }
    }
}
