using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    public int PlayerHealth;

    public int enemiesDefeated;
    //public int powerUpsPicked;

    public int score;

    public int RangerLFEScore;
    public int SlicerLFEScore;

    public int trapMax;

    public int Level;
    public int spawnChance;

    public int spawnCount;
    public int spawnMax;
    public int spawnMaxOrig;

    public bool keyDropped;

    public bool keyPickedUp;

    private float DecreaseTimerRanger;
    private float DecreaseTimerSlicer;
    private float IncreaseTimerOverall;

    public int overallDifficultyScore;

    public int difficultyDecreaseHit;

    public bool isAlive;

    public int playerDamage;

    private bool gamePaused;

    void Awake()
    {
        gamePaused = false;
        isAlive = true;
        Level = 1;
        if (Instance == null)//creates single instance
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DecreaseTimerRanger = 30.0f;
        spawnMax = 5;
        spawnMaxOrig = 5;
        trapMax = 5;
    }

    void Update()
    {
        DifficultyDecrease();
        DifficultyIncrease();
        if (Input.GetKeyDown("q") & gamePaused == false)
        {
            Time.timeScale = 0;
            gamePaused = true;
        }
        else if (Input.GetKeyDown("q") & gamePaused == true)
        {
            Time.timeScale = 1;
            gamePaused = false;
        }
        
    }

    void DifficultyIncrease()
    {
        IncreaseTimerOverall = IncreaseTimerOverall + Time.deltaTime;
        if(IncreaseTimerOverall >= 10.0f & overallDifficultyScore <= 10)//change to 25.0f
        {
            overallDifficultyScore = overallDifficultyScore + 1 + (score / 500);
            IncreaseTimerOverall = 0;
            SpawnIncrease();
        }
        if (overallDifficultyScore >= 10)
        {
            overallDifficultyScore = 10;
        }
    }


    void DifficultyDecrease()
    {
        if (RangerLFEScore >= 2) 
        { 
        DecreaseTimerRanger = DecreaseTimerRanger - Time.deltaTime;
        }
        if(DecreaseTimerRanger <= 0 & RangerLFEScore >= 1)
        {
            RangerLFEScore = RangerLFEScore - 1;
            
            DecreaseTimerRanger = 40.0f + (float)overallDifficultyScore;
        }
        if(SlicerLFEScore >= 2)
        {
            DecreaseTimerSlicer = DecreaseTimerSlicer - Time.deltaTime;
        }
        if(DecreaseTimerSlicer <= 0 & SlicerLFEScore >= 1)
        {
            SlicerLFEScore = SlicerLFEScore - 1;

            DecreaseTimerSlicer = 40.0f + (float)overallDifficultyScore;
        }
        if(difficultyDecreaseHit >= 2 & overallDifficultyScore >= 1)
        {
            overallDifficultyScore = overallDifficultyScore - 1;
            difficultyDecreaseHit = 0;
        }
        if(overallDifficultyScore <= 0)
        {
            overallDifficultyScore = 1;
        }
    }

    

    void SpawnIncrease()
    {
        spawnMax = overallDifficultyScore + spawnMaxOrig;
    }


}
