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
    private AudioClip collectAudio;

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
            AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Spawn at the same position as the gift box
    /// </summary>
    void SpawnCollectible()
    {
        Debug.Log("Spawning collectible at position: " + transform.position);
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }
}
