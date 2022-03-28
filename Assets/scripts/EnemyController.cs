using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 4;
    //public int enemyDamage = 1;

    private int drop;
    public GameObject droppedItem;
    public GameObject droppedItem2;
    public GameObject droppedItem3;

    public Transform player;
    private Rigidbody2D rb;
    private Vector3 directionToPlayer;
    private Vector3 localScale;

    public float moveSpeed = 3f;

    public GameObject Player;
    private PlayerController playerScript;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public LayerMask whatIsPlayer, whatIsGround;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public NavMeshAgent agent;

    void Start()
    {
        playerScript = Player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
    }


    void Update()
    {
        Move();
        Death();
    }

    void FixedUpdate()
    {
        
    }

    


    void Move()
    {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }

    private void AttackPlayer()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerProjectile") { 
            enemyHealth = enemyHealth - playerScript.playerDamage;
    }
        if (other.gameObject.tag == "PlayerMelee")
        {
            enemyHealth = enemyHealth - (playerScript.playerDamage*2);
        }
    }

    void Death()
    {
        if (enemyHealth <= 0)
        {
            drop = Random.Range(0, 10);
            if(drop <= 2)
            {
                Instantiate(droppedItem, transform.position, droppedItem.transform.rotation);
            }
            else if(drop >= 9)
            {
                Instantiate(droppedItem2, transform.position, droppedItem.transform.rotation);
            }
            else
            {
                Instantiate(droppedItem3, transform.position, droppedItem.transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }
}
