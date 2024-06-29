/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Player Input for handling medkit and key pickup
 */

using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private AudioClip collectAudio;

    //Distinguish between different types of pickups like medkits and keys.
    public enum PickupType { Medkit, Key };

    //Type of the pickup (Medkit or Key)
    public PickupType pickupType;

    //Tracks whether the player is within the trigger area
    private bool isInRange = false;

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
                if (pickupType == PickupType.Medkit)
                {
                    AudioSource.PlayClipAtPoint(collectAudio, transform.position, 0.5f);
                    player.AddMedkit();
                }
                else if (pickupType == PickupType.Key)
                {
                    AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
                    player.AddKey();
                }
                Destroy(gameObject);
            }
        }
    }
}
