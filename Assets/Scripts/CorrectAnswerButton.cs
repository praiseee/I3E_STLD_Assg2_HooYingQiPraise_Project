/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Script for handling correct answer button interaction
 */

using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CorrectAnswerButton : MonoBehaviour
{
    public TMP_Text correctText;

    /// <summary>
    /// List of wall objects to destroy upon correct answer
    /// </summary>
    public List<GameObject> wallsToDestroy = new List<GameObject>();

    /// <summary>
    /// Display the correct message. Hide the message after 1 second and destroy the specified walls.
    /// </summary>
    public void OnButtonPress()
    {
        correctText.gameObject.SetActive(true);
        Invoke("HideCorrectMessage", 1f);

        // Loop through all walls to destroy
        foreach (GameObject wall in wallsToDestroy)
        {
            if (wall != null)
            {
                Destroy(wall);
            }
        }
    }

    /// <summary>
    /// Hide Correct message 
    /// </summary>
    void HideCorrectMessage()
    {
        correctText.gameObject.SetActive(false);
    }
}
