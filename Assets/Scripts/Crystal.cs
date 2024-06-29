/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Crystal script for player to collect using collision
 */

using UnityEngine;

public class Crystal : MonoBehaviour
{
    private bool isInRange = false;
    private Player player;

    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// Checks if the collider that entered the collision has the tag "Player"
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            player = collision.gameObject.GetComponent<Player>();
        }
    }

    /// <summary>
    /// Checks if the collider that exited the collision has the tag "Player"
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision exited by: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            player = null;
        }
    }

    /// <summary>
    /// Player to collect crystal when they are within range using the 'E' key.
    /// </summary>
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && player != null)
        {
            player.AddCrystal();
            gameObject.SetActive(false); // Deactivate the crystal 
            AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);

            Debug.Log("Crystal collected");
        }
    }
}
