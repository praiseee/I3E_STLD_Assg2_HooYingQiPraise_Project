/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverScreen;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        // Pause game or handle any other necessary actions when game over
        Time.timeScale = 0; // Freeze game time

        // Activate game over screen UI
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Reset game time scale if necessary
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        // Quit application (works in builds, not in editor)
        Application.Quit();
    }
}

