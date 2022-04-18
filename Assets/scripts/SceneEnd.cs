using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEnd : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("TileMaker");//load main game scene and resets stats
            GameStats.Instance.isAlive = true;
            GameStats.Instance.PlayerHealth = 15;
            GameStats.Instance.spawnCount = 0;
            GameStats.Instance.score = 0;
            GameStats.Instance.Level = 1;

        }
    }
}
