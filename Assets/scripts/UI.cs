using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject Player;
    private PlayerController playerScript;

    public Text Health;
    public Image HealthBar;
    public Image Ammo;

    private float healthPerc = 1.0f;

    private float ammoPerc = 1.0f;

    private int ammoMax = 10;



    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
    }



    void Update()
    {
        healthPerc = (float)playerScript.playerHealth / (float)playerScript.playerHealthMax;
        HealthBar.fillAmount = healthPerc;

        ammoPerc = (float)playerScript.shootCooldown / (float)ammoMax;
        Ammo.fillAmount = ammoPerc;

        Health.text = playerScript.playerHealth.ToString();
    }
}
