using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSpawner : MonoBehaviour
{
    public GameObject leftExit;
    public GameObject topExit;
    public GameObject rightExit;

    

    void Awake()
    {
       // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }


    void Update()
    {
        rightExit.SetActive(false);
        leftExit.SetActive(false);
        topExit.SetActive(false);


        if (GameStats.Instance.spawnChance <= 30)
        {
            leftExit.SetActive(true);
        }
        else if (GameStats.Instance.spawnChance >= 60)
        {
            topExit.SetActive(true);
        }
        else
        {
            rightExit.SetActive(true);
        }
    }
}
