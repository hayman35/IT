﻿using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject rocket;

    public float rocketSpeed = 10f;

    public AudioSource rocketSound;

    public Transform firePoint;

    public Animator animator;

private Transform startTransform;
    public ITManager it;
    public float multiplier = 3; // or more
    public float range = 30;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && it.player_IT == 1) Patroling();
        if (playerInSightRange && !playerInAttackRange && it.player_IT == 1) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && it.player_IT == 1) AttackPlayer();
        if (it.player_IT == 0) RunAway();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed",speed);
        agent.SetDestination(player.position);
    }

    private void RunAway()
    {
       if(playerInSightRange)
       {
           Debug.Log("SEEN");
           Vector3 dirToPlayer = transform.position - player.transform.position;
           Vector3 newPos = transform.position + dirToPlayer;
           agent.SetDestination(newPos);
       }
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            animator.SetTrigger("shoot");
            GameObject rocketGo = Instantiate(rocket,firePoint.position,firePoint.rotation);
            rocketGo.SetActive(true);
            rocketGo.GetComponent<Rigidbody>().AddForce(firePoint.forward * rocketSpeed,ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
