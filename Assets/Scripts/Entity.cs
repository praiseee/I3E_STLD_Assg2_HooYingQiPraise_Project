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
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            UpdateHealthBar();
            Debug.Log("Current Health: " + currentHealth); // Current health

            if (currentHealth <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        currentHealth = startingHealth;
        CreateHealthBar();
    }

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
