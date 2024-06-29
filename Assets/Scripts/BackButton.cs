/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Navigation of using back button
 */

using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject settingsCanvas; 

    /// <summary>
    /// Back button from current canvas to main menu
    /// </summary>
    public void BackToMenu()
    {
        //MenuCanvas is true and SettingsCanvas to false
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }
}



