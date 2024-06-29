/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: instantiate Gift box for a key
 */

using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleToSpawn;

    [SerializeField]
    private AudioClip collisionSound;
    private AudioSource audioSource;

    /// <summary>
    /// Initializes the AudioSource component.
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            PlayCollisionSound();
            SpawnCollectible();
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

    /// <summary>
    /// Plays the collision sound.
    /// </summary>
    void PlayCollisionSound()
    {
        if (collisionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
