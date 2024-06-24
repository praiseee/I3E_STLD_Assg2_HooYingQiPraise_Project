using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    [SerializeField] private float startingHealth = 100f;
    private float currentHealth;

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            UpdateHealthBar();
            Debug.Log("Current Health: " + currentHealth); // Log the current health

            if (currentHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public Slider healthBarPrefab;
    private Slider healthBarInstance;

    private bool healthBarCreated = false; // Flag to track if health bar is already created

    void Start()
    {
        CurrentHealth = startingHealth;
        if (!healthBarCreated)
        {
            CreateHealthBar(); // Create health bar only if it's not already created
            healthBarCreated = true;
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarInstance != null)
        {
            healthBarInstance.value = currentHealth / startingHealth;
        }
    }

    void CreateHealthBar()
    {
        healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
        healthBarInstance.transform.SetParent(GameObject.Find("Canvas").transform); // Set parent to Canvas
        healthBarInstance.transform.localScale = Vector3.one; // Reset scale
    }
}
