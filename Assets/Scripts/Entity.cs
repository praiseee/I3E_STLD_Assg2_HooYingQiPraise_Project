/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar Script 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private float startingHealth = 100f;
    private float currentHealth;

    public Slider healthBarPrefab;
    private Slider healthBarInstance;

    public float CurrentHealth
    {
        /// <summary>
        /// To retrieve the value of the currentHealth
        /// </summary>
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
            UpdateHealthBar(); // Update the health bar UI to reflect the new health value.
            Debug.Log("Current Health: " + currentHealth); // Current health

            if (currentHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Sets the current health of the entity to the starting health value
    /// </summary>
    void Start()
    {
        currentHealth = startingHealth;
        CreateHealthBar();
    }

    /// <summary>
    /// Verifies if the health bar instance exists
    /// </summary>
    void UpdateHealthBar()
    {
        if (healthBarInstance != null)
        {
            healthBarInstance.value = currentHealth / startingHealth;
            Debug.Log("Health Bar Value: " + healthBarInstance.value); // Slider value
        }
        else
        {
            Debug.LogError("Health bar instance is null!");
        }
    }

    /// <summary>
    /// Verifies if the health bar prefab is assigned.
    /// </summary>
    void CreateHealthBar()
    {
        if (healthBarPrefab != null)
        {
            healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
            healthBarInstance.transform.SetParent(GameObject.Find("Canvas").transform, false); 
            healthBarInstance.transform.localScale = Vector3.one;
        }
        else
        {
            Debug.LogError("Health bar prefab is not assigned!");
        }
    }
}
