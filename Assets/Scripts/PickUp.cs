/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Pickup script for handling medkit and key pickup
 */

using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType { Medkit, Key };
    public PickupType pickupType; // Type of the pickup (Medkit or Key)
    private bool isInRange = false; // Tracks whether the player is within the trigger area

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
    /// If collision occurs and player is detected, pickup is collected
    /// </summary>
    void Update()
    {
        if (isInRange && Input.GetButtonDown("Use"))
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                if (pickupType == PickupType.Medkit)
                {
                    player.AddMedkit();
                }
                else if (pickupType == PickupType.Key)
                {
                    player.AddKey();
                }
                Destroy(gameObject);
            }
        }
    }
}
