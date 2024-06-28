/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Crystal script for player to collect
 */

using UnityEngine;

public class Crystal : MonoBehaviour
{
    private bool isInRange = false;

    /// <summary>
    /// Checks if the collider that entered the trigger has the tag "Player"
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    /// <summary>
    /// Checks if the collider that exited the trigger has the tag "Player"
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    /// <summary>
    /// Player to collect crystal when they are within range using the 'E' key.
    /// </summary>
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                player.AddCrystal();
                gameObject.SetActive(false); // Deactivate the crystal 
            }
        }
    }
}
