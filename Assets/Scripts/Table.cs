/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Table script for spawning a collectible when the player presses 'E', congratulatory message
 */

using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleToSpawn;

    [SerializeField]
    private GameObject congratulatoryCanvas; // Reference to the congratulatory canvas

    private bool isInRange = false;

    /// <summary>
    /// Logs the name of the GameObject that collided with the table
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with the table.");
            isInRange = true;
        }
    }

    /// <summary>
    /// Checks if the collider that exited the collision has the tag "Player"
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited collision with the table.");
            isInRange = false;
        }
    }

    /// <summary>
    /// Update function to check for 'E' key press and spawn collectible if player is in range
    /// </summary>
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed, spawning collectible and showing congratulatory canvas.");
            SpawnCollectible();
            ShowCongratulatoryCanvas();
        }
    }

    /// <summary>
    /// Spawn the collectible at the same position as the table
    /// </summary>
    void SpawnCollectible()
    {
        Debug.Log("Spawning collectible at position: " + transform.position);
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
        isInRange = false; // Prevent spawning multiple collectibles with one key press
    }

    /// <summary>
    /// Show the congratulatory canvas and enable cursor for interaction
    /// </summary>
    void ShowCongratulatoryCanvas()
    {
        congratulatoryCanvas.SetActive(true);
        Time.timeScale = 0; // Pause the game
        Cursor.lockState = CursorLockMode.None; // Unlock cursor for UI interaction
        Cursor.visible = true; // Show cursor for UI interaction
    }

    /// <summary>
    /// Hide the congratulatory canvas and resume game
    /// </summary>
    void HideCongratulatoryCanvas()
    {
        congratulatoryCanvas.SetActive(false);
        Time.timeScale = 1; // Resume the game
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor
        Cursor.visible = false; // Hide cursor
    }

    /// <summary>
    /// Method to handle clicking on Restart button in the congratulatory canvas
    /// </summary>
    public void OnClickRestart()
    {
        GameManager.Instance.RestartGame();
        HideCongratulatoryCanvas();
    }

    /// <summary>
    /// Method to handle clicking on Main Menu button in the congratulatory canvas
    /// </summary>
    public void OnClickMainMenu()
    {
        GameManager.Instance.MainMenu();
        HideCongratulatoryCanvas();
    }
}
