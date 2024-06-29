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
        //Tnsure only one instance of GameManager exists
        if (Instance == null)
            Instance = this;
        else
        {
            //Destroy duplicate GameManager instances
            Destroy(gameObject);
            return;
        }

        //Preserve GameManager across scene loads
        DontDestroyOnLoad(gameObject);
        gameOverScreen.SetActive(false);
    }

    //When game is over
    public void GameOver()
    {
        PauseGame();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; 
        Cursor.lockState = CursorLockMode.None;
    }

    //Restart the game
    public void RestartGame()
    {
        //Reload current scene
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    //Quit the application
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //To pause the game
    void PauseGame()
    {
        Time.timeScale = 0; // Freeze game time
    }
}
