using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent; // NavMeshAgent component for pathfinding
    public Transform player; // Reference to the player's transform

    /// <summary>
    /// LayerMask to only interact with objects on these layers.
    /// </summary>
    public LayerMask Ground, Player; // Layers for ground and player detection

    /// <summary>
    /// Patrolling
    /// </summary>
    public Vector3 walkPoint; // Current walk point destination
    bool walkPointSet; // Whether the walk point is set
    public float walkPointRange; // Range for setting walk points

    /// <summary>
    /// Attacking
    /// </summary>
    public float timeBetweenAttacks; // Time between attacks
    bool alreadyAttacked; // Whether the enemy has already attacked

    /// <summary>
    /// States
    /// </summary>
    public float sightRange, attackRange; // Sight and attack ranges
    public bool playerInSightRange, playerInAttackRange; // Booleans for player detection

    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform firePoint; // The point from where the projectile will be fired

    /// <summary>
    /// Called when the script instance is being loaded
    /// </summary>
    private void Awake()
    {
        player = GameObject.Find("PlayerCapsule").transform; // Finds the player object
        agent = GetComponent<NavMeshAgent>(); // Gets the NavMeshAgent component
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        // Check if the player is in sight or attack range
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
        agent.SetDestination(transform.position); // Stop the enemy from moving

        transform.LookAt(player); // Face the player

        if (!alreadyAttacked)
        {
            ShootProjectile(); // Shoot a projectile at the player
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); // Reset the attack
        }
    }

    /// <summary>
    /// Instantiate the projectile and shoot it
    /// </summary>
    private void ShootProjectile()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation); // Instantiate the projectile
    }

    /// <summary>
    /// Reset the attack status
    /// </summary>
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
