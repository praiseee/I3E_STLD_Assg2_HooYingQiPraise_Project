/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Enemy AI Parol and chase
 */

using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    /// <summary>
    /// LayerMask to only interact with objects on these layers.
    /// </summary>
    public LayerMask whatIsGround, whatIsPlayer;

    /// <summary>
    /// Patrolling
    /// </summary>
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    /// <summary>
    /// Attacking
    /// </summary>
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    /// <summary>
    /// States
    /// </summary>
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    /// <summary>
    /// Called when the script instance is being loaded
    /// </summary>
    public void Awake()
    {
        player = GameObject.Find("PlayerCapsule").transform; ///Finds a GameObject named "PlayerCapsule" in the scene.
        agent = GetComponent<NavMeshAgent>(); ///Responsible for pathfinding and navigation in Unity using the NavMesh system.
    }

    // Update is called once per frame
    private void Update()
    {
        /// <summary>
        /// Check for player in sight and attack at range
        /// </summary>
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
    }

    /// <summary>
    /// Move AI character to random points
    /// </summary>
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        /// <summary>
        /// Walkpoint Reached
        /// </summary>
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        /// <summary>
        /// Calculate random point range
        /// </summary>
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        /// <summary>
        /// To verify if the randomly generated walkPoint is on the ground
        /// </summary>

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}