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
        SceneManager.LoadScene("Main");
    }

    public void SettingsOptions()
    {
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
