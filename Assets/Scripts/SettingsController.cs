/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar
 */

using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI Slider
    public AudioClip audioClip; // Reference to the AudioClip

    private AudioSource audioSource; // Private AudioSource for playing the clip

    void Start()
    {
        // Create an AudioSource component dynamically
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; // Optional: Loop the audio if needed

        // Set initial volume
        audioSource.volume = 0.5f; // Set a default volume value
        volumeSlider.value = audioSource.volume;

        // Add listener to handle value changes
        volumeSlider.onValueChanged.AddListener(SetVolume);

        audioSource.Play(); // Play the audio once during Start
        Debug.Log("AudioSource initialized and playing.");
    }

    // Method to set the volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        Debug.Log("Volume set to: " + volume);
    }
}
