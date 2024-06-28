/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Crystal script for player to collect
 */

using UnityEngine;

public class Crystal : MonoBehaviour
{
    private bool isInRange = false;

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

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                player.AddCrystal();
                gameObject.SetActive(false); // Deactivate the crystal instead of destroying it
            }
        }
    }
}
