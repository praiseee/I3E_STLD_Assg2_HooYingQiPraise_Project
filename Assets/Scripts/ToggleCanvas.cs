/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Handle different menus in main game, includes toggle
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleCanvas : MonoBehaviour
{
    public Canvas canvasToToggle;
    public Canvas instructionCanvas;
    public Canvas toggleCanvas;

    private bool isCanvasActive;
    private bool isGamePaused;

    private void Start()
    {
        isCanvasActive = canvasToToggle.gameObject.activeSelf;
        isGamePaused = false; // Initialize game pause state
    }

    private void Update()
    {
        // Check if the "Tab" key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //State of the canvas
            isCanvasActive = !isCanvasActive;
            canvasToToggle.gameObject.SetActive(isCanvasActive);

            //Game pause state
            isGamePaused = isCanvasActive;
            ToggleGamePause(isGamePaused);
        }
    }

    /// <summary>
    /// Load scene back to menu
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Enable the Canvas and disable the other Canvases
    /// </summary>

    public void Instruction()
    {
        instructionCanvas.gameObject.SetActive(true);
        toggleCanvas.gameObject.SetActive(false);

        // Pause the game when instruction canvas is active
        ToggleGamePause(true);
    }

    public void BackButton()
    {
        toggleCanvas.gameObject.SetActive(true);
        instructionCanvas.gameObject.SetActive(false);
        Debug.Log("Back button Click");

        // Resume the game when returning from instruction canvas
        ToggleGamePause(false);
    }

    private void ToggleGamePause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0; // Freeze game time
            Cursor.lockState = CursorLockMode.None; // Unlock cursor
        }
        else
        {
            Time.timeScale = 1; // Resume game time
            Cursor.lockState = CursorLockMode.Locked; // Lock cursor
        }
    }
}
