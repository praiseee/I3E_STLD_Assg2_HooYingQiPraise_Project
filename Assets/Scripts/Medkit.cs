/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Medkit script for handling medkit pickup and usage
 */

using UnityEngine;

public class Medkit : MonoBehaviour
{
    /// <summary>
    ///  tracks whether the player is within the trigger area of the medkit.
    /// </summary>
    /// 
    private bool isInRange = false;

    void Update()
    {
        if (isInRange && Input.GetButtonDown("Use"))
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                player.AddMedkit();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
