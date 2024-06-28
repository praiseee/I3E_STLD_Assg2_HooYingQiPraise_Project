/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Canvas mainMenuCanvas; // Reference to the main menu canvas
    public Canvas settingsCanvas; // Reference to the settings canvas

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void SettingsOptions()
    {
        // Enable the SettingsCanvas and disable the MainMenuCanvas
        settingsCanvas.gameObject.SetActive(true);
        mainMenuCanvas.gameObject.SetActive(false);
        Debug.Log("Options button clicked");
    }

    public void ShowCredits()
    {
        Debug.Log("Credits button clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

