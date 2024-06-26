/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Script for handling wrong answer button interaction
 */

using UnityEngine;

public class WrongAnswerButton : MonoBehaviour
{
    public Player player;
    public int damageAmount = 5;

    /// <summary>
    /// Inflict damage to the player for a wrong answer
    /// </summary>
    public void OnButtonPress()
    {
        // Inflict damage to the player for a wrong answer
        player.TakeDamage(damageAmount);
    }
}
