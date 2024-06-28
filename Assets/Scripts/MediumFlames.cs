/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: MediumFlames that reduces player health when touched
 */

using UnityEngine;

public class MediumFlames : MonoBehaviour
{
    /// <summary>
    /// Damages the player character upon collision.
    /// </summary>
    /// <param name="other"></param>

    /// <summary>
    /// Check if the object entering the trigger is the player
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(4);
        }
    }
}

