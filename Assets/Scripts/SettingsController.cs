using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider; //UI Slider
    public AudioClip audioClip; //AudioClip

    private AudioSource audioSource;


    // Create an AudioSource component dynamically
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; 

        //Initial volume
        audioSource.volume = 1f; 
        volumeSlider.value = audioSource.volume;

        //Add listener to handle value changes
        volumeSlider.onValueChanged.AddListener(SetVolume);

        audioSource.Play(); // Play the audio once during Start
        Debug.Log("AudioSource initialized and playing.");
    }

    //To set the volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        Debug.Log("Volume set to: " + volume);
    }
}
