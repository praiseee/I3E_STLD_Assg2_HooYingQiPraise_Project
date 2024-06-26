/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar
 */

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    /// <summary>
    /// Updates the current health value displayed on the health bar.
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(float health)
    {
        //Updates the slider's value to the current health value, 
        slider.value = health;
        Debug.Log("Current health:" + slider.value);
    }

    /// <summary>
    ///  Sets the maximum health value and initializes the health bar to its maximum state
    /// </summary>
    /// <param name="max"></param>
    public void SetMaxHealth(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }
}
