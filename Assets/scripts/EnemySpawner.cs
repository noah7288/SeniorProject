using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;

    public Transform spawner;
    private int enemySpawnChance;

    

    void Start()
    {
        enemySpawnChance = Random.Range(0, 100);//probability to decide whether enemy spawns
        if(enemySpawnChance <= (30 + GameStats.Instance.overallDifficultyScore + GameStats.Instance.Level) - (GameStats.Instance.RangerLFEScore * 2) & GameStats.Instance.spawnCount <= GameStats.Instance.spawnMax)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawner.position, spawner.rotation);
            GameStats.Instance.spawnCount++;
        }
        else if(enemySpawnChance >= (85 - GameStats.Instance.overallDifficultyScore - GameStats.Instance.Level) + (GameStats.Instance.SlicerLFEScore * 2) & GameStats.Instance.spawnCount <= GameStats.Instance.spawnMax)
        { 
            GameObject enemy = Instantiate(enemyPrefab2, spawner.position, spawner.rotation);
            GameStats.Instance.spawnCount++;
        }
    }


}
