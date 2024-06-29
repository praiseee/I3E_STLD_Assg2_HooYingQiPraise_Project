/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Handle audio output interactivity
 */

using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioClip audioClip; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;

        //Initial volume
        audioSource.volume = 1f;
        volumeSlider.value = audioSource.volume;

        //Listener to handle value changes
        volumeSlider.onValueChanged.AddListener(SetVolume);

        audioSource.Play(); // Play the audio once during Start
        Debug.Log("AudioSource initialized and playing.");
    }

    //Set the volume based on slider value
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        Debug.Log("Volume set to: " + volume);

        // Ensure audio is muted when volume is set to 0
        if (volume <= 0.001f)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }
}

