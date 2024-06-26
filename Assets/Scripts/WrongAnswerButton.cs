/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Script for handling wrong answer button interaction
 */

using UnityEngine;

public class WrongAnswerButton : MonoBehaviour
{
    public Player player; // Reference to the Player script for health management
    public int damageAmount = 5; // Amount of damage to inflict on the player for a wrong answer

    public void OnInteract()
    {
        // Inflict damage to the player for a wrong answer
        player.TakeDamage(damageAmount);

        // Optionally, you can add more functionality here for wrong answer handling
        // For example, displaying a message, playing an animation, etc.
    }
}
