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
    public Text EnemiesDefeated;

    public Image damageBoost;
    public Image key;

    private float healthPerc = 1.0f;

    private float ammoPerc = 1.0f;

    private int ammoMax = 10;

    public Text Level;

    public Text Remaining;

    public Text Difficulty;

    public Image guideT;
    public Image guideL;
    public Image guideR;


    void Start()
    {
        damageBoost.fillAmount = 0.0f;
        key.fillAmount = 0.0f;
        playerScript = Player.GetComponent<PlayerController>();
    }



    void Update()
    {
        healthPerc = (float)playerScript.playerHealth / (float)playerScript.playerHealthMax;
        HealthBar.fillAmount = healthPerc;

        if(playerScript.damageBoosted == true)
        {
            damageBoost.fillAmount = 1.0f;
        }
        else if (playerScript.damageBoosted == false)
        {
            damageBoost.fillAmount = 0.0f;
        }

        ammoPerc = (float)playerScript.shootCooldown / (float)ammoMax;
        Ammo.fillAmount = ammoPerc;

        Health.text = playerScript.playerHealth.ToString();

        EnemiesDefeated.text = GameStats.Instance.score.ToString();

        Level.text = GameStats.Instance.Level.ToString();

        Remaining.text = GameStats.Instance.spawnCount.ToString();

        if(GameStats.Instance.keyPickedUp == true)
        {
            key.fillAmount = 1.0f;
        }
        else if(GameStats.Instance.keyPickedUp == false)
        {
            key.fillAmount = 0.0f;
        }

        Difficulty.text = GameStats.Instance.overallDifficultyScore.ToString();
        Guide();
        }

    void Guide()
    {
        if (GameStats.Instance.spawnChance <= 30)//sets left guide
        {
            guideL.fillAmount = 1.0f;
            guideR.fillAmount = 0.0f;
            guideT.fillAmount = 0.0f;
        }
        else if (GameStats.Instance.spawnChance >= 60)//sets top guide
        {
            guideT.fillAmount = 1.0f;
            guideL.fillAmount = 0.0f;
            guideR.fillAmount = 0.0f;
        }
        else//sets right guide
        {
            guideR.fillAmount = 1.0f;
            guideL.fillAmount = 0.0f;
            guideT.fillAmount = 0.0f;
        }
    }
}
