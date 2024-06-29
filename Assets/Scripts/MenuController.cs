/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Navigation between different menus in a game
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Canvas mainMenuCanvas; 
    public Canvas settingsCanvas;
    public Canvas menuCanvas;
    public Canvas creditCanvas;
    public Canvas instructionCanvas;

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
        Debug.Log("Back button Click");
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
