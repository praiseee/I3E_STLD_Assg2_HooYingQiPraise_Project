/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Player Input for handling medkit and key pickup
 */

using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Distinguish between different types of pickups like medkits and keys.
    public enum PickupType { Medkit, Key };

    //Type of the pickup (Medkit or Key)
    public PickupType pickupType;

    //Tracks whether the player is within the trigger area
    private bool isInRange = false;

    [SerializeField]
    private AudioClip pickupSound;
    private AudioSource audioSource;

    /// <summary>
    /// Initializes the AudioSource component
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// To detect when the player enters trigger zone
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    /// <summary>
    /// To detect when the player exits trigger zone
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    /// <summary>
    /// If collision occurs and player is detected, pickup is collected. (Key or Medkit)
    /// </summary>
    void Update()
    {
        if (isInRange && Input.GetButtonDown("Use"))
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                PlayPickupSound();
                if (pickupType == PickupType.Medkit)
                {
                    player.AddMedkit();
                }
                else if (pickupType == PickupType.Key)
                {
                    player.AddKey();
                }
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Plays the pickup sound.
    /// </summary>
    void PlayPickupSound()
    {
        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }
}
