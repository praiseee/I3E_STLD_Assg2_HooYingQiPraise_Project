/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Player script handling health, damage, and medkits
 */

using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar playerHealthBar;
    private int medkitCount = 0; // To track the number of medkits the player has

    void Start()
    {
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth); // Initialize max health
        playerHealthBar.SetHealth(currentHealth); // Initialize current health display
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.F) && medkitCount > 0)
        {
            UseMedkit();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth); // Update current health display

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.GameOver();
    }

    public void AddMedkit()
    {
        medkitCount++;
        Debug.Log("Medkit picked up. Total medkits: " + medkitCount);
    }

    void UseMedkit()
    {
        if (medkitCount > 0)
        {
            currentHealth = Mathf.Min(currentHealth + 5, maxHealth); // Increase health but not above maxHealth
            playerHealthBar.SetHealth(currentHealth); // Update current health display
            medkitCount--;
            Debug.Log("Used a medkit. Remaining medkits: " + medkitCount);
        }
        else
        {
            Debug.Log("No medkits left to use.");
        }
    }
}
