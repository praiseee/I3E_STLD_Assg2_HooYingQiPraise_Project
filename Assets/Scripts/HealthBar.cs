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

    public void SetHealth(float health)
    {
        slider.value = health;
        Debug.Log("Current health:" + slider.value);
    }

    public void SetMaxHealth(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }
}
