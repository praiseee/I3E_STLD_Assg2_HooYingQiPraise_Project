/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar with Slider and TextMeshPro
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Reference to the slider component
    public TMP_Text healthText; // Reference to the TextMeshPro text component

    /// <summary>
    /// Updates the current health value displayed on the slider and text.
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(float health)
    {
        // Update the slider's value
        slider.value = health;

        // Update the TextMeshPro text
        healthText.text = "Health: " + health.ToString();
        Debug.Log("Current health:" + health);
    }

    /// <summary>
    /// Sets the maximum health value for the slider.
    /// </summary>
    /// <param name="max"></param>
    public void SetMaxHealth(float max)
    {
        // Set the slider's max value
        slider.maxValue = max;

        // Optionally, you can initialize the slider's current value to max
        slider.value = max;
    }
}
