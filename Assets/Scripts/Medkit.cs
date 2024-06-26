/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Medkit script for handling medkit pickup and usage
 */

using UnityEngine;

public class Medkit : MonoBehaviour
{
    /// <summary>
    /// Tracks whether the player is within the trigger area of the medkit.
    /// </summary>
    private bool isInRange = false;

    /// <summary>
    /// To detect when the player enters trigger zone
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
    /// To detect when the player exits trigger zone
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
    /// If collision occurs and player is detected, medkit is picked up
    /// </summary>
    void Update()
    {
        if (isInRange && Input.GetButtonDown("Use"))
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                player.AddMedkit();
                Destroy(gameObject);
            }
        }
    }
}
