/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar
 */

using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject menuCanvas; //MenuCanvas GameObject
    public GameObject settingsCanvas; //SettingsCanvas GameObject

    /// <summary>
    /// Back button from current canvas to main menu
    /// </summary>
    public void BackToMenu()
    {
        //MenuCanvas to true and SettingsCanvas to false
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false); //Deactivate SettingsCanvas
    }
}



