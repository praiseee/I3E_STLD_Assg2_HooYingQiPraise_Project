/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: instantiate Gift box for a key
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleToSpawn;

    [SerializeField]
    private Vector3 spawnOffset; // Offset to adjust the spawn position of the collectible

    /// <summary>
    /// Logs the name of the GameObject that the gift box collided with
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with the gift box.");
            SpawnCollectible();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Spawn at the same position as the gift box with an optional offset
    /// </summary>
    void SpawnCollectible()
    {
        Vector3 spawnPosition = transform.position + spawnOffset;
        Debug.Log("Spawning collectible at position: " + spawnPosition);
        Instantiate(collectibleToSpawn, spawnPosition, collectibleToSpawn.transform.rotation);
    }
}
