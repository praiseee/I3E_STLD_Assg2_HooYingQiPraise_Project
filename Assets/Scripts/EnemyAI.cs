/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: EnemyAI script for patrolling
 */

using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent; //Component for pathfinding
    public Transform player; //Player's transform

    /// <summary>
    /// Iinteract with objects on these layers.
    /// </summary>
    public LayerMask Ground, Player; 

    /// <summary>
    /// Patrolling
    /// </summary>
    public Vector3 walkPoint; //Current walk point destination
    bool walkPointSet; //Is the walkpoint set?
    public float walkPointRange; //Range for setting walk points

    /// <summary>
    /// Attacking
    /// </summary>
    public float timeBetweenAttacks; //Time between attacks
    bool alreadyAttacked; //Check if enemy has already attacked

    /// <summary>
    /// States for Sight and attack ranges
    /// </summary>
    public float sightRange, attackRange; 
    public bool playerInSightRange, playerInAttackRange;

    /// <summary>
    /// Reference to the projectile prefab, where the projectile will be fired
    /// </summary>
    public GameObject projectilePrefab; 
    public Transform firePoint; 

    /// <summary>
    /// Called when the script is being loaded
    /// </summary>
    private void Awake()
    {
        player = GameObject.Find("PlayerCapsule").transform; // Finds the player object
        agent = GetComponent<NavMeshAgent>(); // Gets the NavMeshAgent component
    }

    /// <summary>
    /// Check if the player is in sight or attack range
    /// </summary>
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
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

        // Walkpoint Reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    /// <summary>
    /// Calculate random walk point within range
    /// </summary>
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Ensure the walk point is on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))
            walkPointSet = true;
    }

    /// <summary>
    /// Chase the player
    /// </summary>
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    /// <summary>
    /// Attack the player
    /// </summary>
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position); //Stop the enemy from moving

        transform.LookAt(player); //Face the player

        if (!alreadyAttacked)
        {
            ShootProjectile(); //Shoot projectile at the player
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); //Reset the attack
        }
    }

    /// <summary>
    /// Instantiate the projectile and shoot it
    /// </summary>
    private void ShootProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); // Instantiate projectile
    }

    /// <summary>
    /// Reset the attack 
    /// </summary>
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
