/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Script for handling correct answer button interaction
 */

using UnityEngine;
using TMPro;

public class CorrectAnswerButton : MonoBehaviour
{
    public TMP_Text correctText; // Reference to the TextMeshPro text for correct message

    public void OnInteract()
    {
        // Display the correct message
        correctText.gameObject.SetActive(true);
        Invoke("HideCorrectMessage", 5f); // Hide the message after 5 seconds

        // Optionally, you can add more functionality here for correct answer handling
        // For example, awarding points, progressing to the next question, etc.
    }

    void HideCorrectMessage()
    {
        correctText.gameObject.SetActive(false);
    }
}

