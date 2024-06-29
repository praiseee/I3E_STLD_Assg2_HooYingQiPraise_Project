/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Table script for spawning a collectible when the player presses 'E'
 */

using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleToSpawn;

    private bool isInRange = false;

    /// <summary>
    /// Logs the name of the GameObject that collided with the table
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with the table.");
            isInRange = true;
        }
    }

    /// <summary>
    /// Checks if the collider that exited the collision has the tag "Player"
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited collision with the table.");
            isInRange = false;
        }
    }

    /// <summary>
    /// Update function to check for 'E' key press and spawn collectible if player is in range
    /// </summary>
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed, spawning collectible.");
            SpawnCollectible();
        }
    }

    /// <summary>
    /// Spawn at the same position as the table
    /// </summary>
    void SpawnCollectible()
    {
        Debug.Log("Spawning collectible at position: " + transform.position);
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
        isInRange = false; // Prevent spawning multiple collectibles with one key press
    }
}
