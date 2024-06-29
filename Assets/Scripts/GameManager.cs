/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Managing game state such as game over, restart, and quit functionality, including trigger-based canvas popup and pause.
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverScreen;
    public List<GameObject> popupCanvases;  // List to hold multiple popup canvases
    private bool isPopupActive = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        gameOverScreen.SetActive(false);

        // Deactivate all popup canvases initially
        foreach (GameObject popupCanvas in popupCanvases)
        {
            popupCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (isPopupActive && Input.GetKeyDown(KeyCode.Return))
        {
            ResumeGame();
        }
    }

    public void GameOver()
    {
        PauseGame();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        DeactivateAllPopups(); // Ensure all popups are deactivated when resuming
        isPopupActive = false;
    }

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

    private IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        if (isPopupActive)
        {
            ResumeGame();
        }
    }

    private void DeactivateAllPopups()
    {
        foreach (GameObject popupCanvas in popupCanvases)
        {
            popupCanvas.SetActive(false);
        }
    }
}

