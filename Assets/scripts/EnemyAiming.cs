using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming : MonoBehaviour
{

    private Transform player;
    public GameObject EnemyMelee;
    public float dist;

    public float meleeTime;

    void Start()
    {

        player = GameObject.FindWithTag("Player").transform;
        EnemyMelee.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);
        if(dist <= 3)
        {
            EnemyMelee.SetActive(true);
            if (meleeTime <= -0.1)
            {
                meleeTime = 0.5f;
            }
        }
        if (meleeTime <= 0)
        {
            EnemyMelee.SetActive(false);
        }
        meleeTime = meleeTime - Time.deltaTime;
    }
}
