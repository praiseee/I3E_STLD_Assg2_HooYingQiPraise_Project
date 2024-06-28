/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Managing game state such as game over, restart, and quit functionality.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverScreen;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager instances
            return;
        }

        DontDestroyOnLoad(gameObject); // Preserve GameManager across scene loads

        gameOverScreen.SetActive(false);
    }

    // Method called when the game is over
    public void GameOver()
    {
        PauseGame();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; 
        Cursor.lockState = CursorLockMode.None;
    }

    // Method to restart the game
    public void RestartGame()
    {
        // Reload current scene
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Method to quit the application
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Method to pause the game
    void PauseGame()
    {
        Time.timeScale = 0; // Freeze game time
    }
}
