/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar
 */

using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject menuCanvas; // Reference to the MenuCanvas GameObject

    public void BackToMenu()
    {
        // Set the active state of MenuCanvas to true and SettingsCanvas to false
        menuCanvas.SetActive(true);
        gameObject.SetActive(false); // Deactivate the current SettingsCanvas
    }
}


