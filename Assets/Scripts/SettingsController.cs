/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Script for handling wrong answer button interaction
 */


using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI Slider
    public AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Initialize the slider value with the current volume
        volumeSlider.value = audioSource.volume;

        // Add listener to handle value changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Method to set the volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}

