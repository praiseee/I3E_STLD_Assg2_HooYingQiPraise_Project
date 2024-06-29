/*
 * Author: Hoo Ying Qi Praise
 * Date: 29/06/2024
 * Description: Toggle a canvas with the Tab key and handle menu navigation
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleCanvas : MonoBehaviour
{
    public Canvas canvasToToggle;
    public Canvas mainMenuCanvas;
    public Canvas settingsCanvas;
    public Canvas menuCanvas;
    public Canvas creditCanvas;
    public Canvas instructionCanvas;

    private void Update()
    {
        // Check if the "Tab" key is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle the active state of the canvas
            canvasToToggle.gameObject.SetActive(!canvasToToggle.gameObject.activeSelf);
        }
    }

    /// <summary>
    /// Player get to play game, scene is switched to main
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// Enable the Canvas and disable the other Canvases
    /// </summary>
    public void SettingsOptions()
    {
        settingsCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(false);
        Debug.Log("Options button clicked");
    }

    public void ShowCredits()
    {
        creditCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(false);
        Debug.Log("Credits button clicked");
    }

    public void BackButton()
    {
        menuCanvas.gameObject.SetActive(true);
        settingsCanvas.gameObject.SetActive(false);
        creditCanvas.gameObject.SetActive(false);
        instructionCanvas.gameObject.SetActive(false);
        Debug.Log("Back button clicked");
    }

    public void HowToPlay()
    {
        menuCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
        creditCanvas.gameObject.SetActive(false);
        instructionCanvas.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
