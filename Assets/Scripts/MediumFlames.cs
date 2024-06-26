/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: MediumFlames hazard script that reduces player health when touched.
 */

using UnityEngine;

public class MediumFlames : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            // Reduce player's health by 2
            player.TakeDamage(2);
        }
    }
}

