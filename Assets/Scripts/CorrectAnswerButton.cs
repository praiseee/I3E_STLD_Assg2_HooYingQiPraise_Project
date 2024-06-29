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
    public List<GameObject> wallsToDestroy = new List<GameObject>();
    public AudioClip correctSound; // Assigned in the Unity Editor

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    /// <summary>
    /// Display the correct message. Hide the message after 1 second and destroy the specified walls.
    /// Play correct sound when button is pressed.
    /// </summary>
    public void OnButtonPress()
    {
        correctText.gameObject.SetActive(true);
        Invoke("HideCorrectMessage", 1f);

        // Play correct sound
        if (correctSound != null && audioSource != null)
        {
            audioSource.clip = correctSound; // Assign the correct sound clip
            audioSource.Play();
        }

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
