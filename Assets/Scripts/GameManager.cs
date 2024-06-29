/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Managing game state such as game over, restart, and quit,canvas popup and pause.
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverScreen;
    public List<GameObject> popupCanvases; // List to hold multiple popup canvases
    private bool isPopupActive = false;

    // Variables to track player progress across scenes
    public int keyCount = 0;
    public int crystalCount = 0;

    /// <summary>
    /// Checking if there are any game managers in the scene
    /// </summary>
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        gameOverScreen.SetActive(false);

        // Deactivate all popup canvases initially
        foreach (GameObject popupCanvas in popupCanvases)
        {
            popupCanvas.SetActive(false);
        }
    }

    /// <summary>
    /// Checks if a popup is active and the Return key is pressed to resume the game
    /// </summary>
    void Update()
    {
        if (isPopupActive && Input.GetKeyDown(KeyCode.Return))
        {
            ResumeGame();
        }
    }

    /// <summary>
    /// Handles game over state by pausing the game and showing game over screen
    /// </summary>
    public void GameOver()
    {
        PauseGame();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Show cursor for UI interaction
    }

    /// <summary>
    /// Restarts the current game scene by reloading
    /// </summary>
    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Cursor.visible = false; // Hide cursor after resuming game
    }

    /// <summary>
    /// Loads the main menu scene
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Pauses the game
    /// </summary>
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// Resumes the game and deactivates all popups
    /// </summary>
    void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor when game resumes
        Cursor.visible = false; // Hide cursor when game resumes
        DeactivateAllPopups(); // Ensure all popups are deactivated when resuming
        isPopupActive = false;
    }

    /// <summary>
    /// Triggers a popup canvas by its index
    /// </summary>
    /// <param name="popupIndex"></param>
    public void TriggerPopup(int popupIndex)
    {
        if (popupIndex >= 0 && popupIndex < popupCanvases.Count)
        {
            DeactivateAllPopups(); // Deactivate all other popups before activating the new one
            popupCanvases[popupIndex].SetActive(true);
            PauseGame();
            isPopupActive = true;
            StartCoroutine(ResumeAfterDelay(5f));
        }
        else
        {
            Debug.LogWarning("Popup index out of range.");
        }
    }

    /// <summary>
    /// Coroutine to resume the game after a specified delay
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    private IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        if (isPopupActive)
        {
            ResumeGame();
        }
    }

    /// <summary>
    /// Deactivates all popup canvases
    /// </summary>
    private void DeactivateAllPopups()
    {
        foreach (GameObject popupCanvas in popupCanvases)
        {
            popupCanvas.SetActive(false);
        }
    }

    // Methods to manage key and crystal counts
    public void AddKey()
    {
        keyCount++;
    }

    public int GetKeyCount()
    {
        return keyCount;
    }

    public void AddCrystal()
    {
        crystalCount++;
    }

    public int GetCrystalCount()
    {
        return crystalCount;
    }
}
