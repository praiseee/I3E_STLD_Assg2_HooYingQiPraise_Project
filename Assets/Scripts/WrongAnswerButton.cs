/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Script for handling wrong answer button interaction
 */

using TMPro;
using UnityEngine;

public class WrongAnswerButton : MonoBehaviour
{
    public Player player;
    public int damageAmount = 5;
    public TMP_Text wrongText;

    /// <summary>
    /// Inflict damage to the player for a wrong answer
    /// </summary>
    public void OnButtonPress()
    {
        // Inflict damage to the player for a wrong answer
        player.TakeDamage(damageAmount);

        // Hide the wrong text after a delay
        wrongText.gameObject.SetActive(true);
        Invoke("HideWrongMessage", 1f);
    }

    // Method to hide the wrong message text
    void HideWrongMessage()
    {
        wrongText.gameObject.SetActive(false);
    }
}

