/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Load the game scene
        SceneManager.LoadScene("Main");
    }

    public void SettingsOptions()
    {
        // Implement options menu logic here
        Debug.Log("Options button clicked");
    }

    public void ShowCredits()
    {
        // Implement credits logic here
        Debug.Log("Credits button clicked");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
