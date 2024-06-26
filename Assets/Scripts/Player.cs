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
    private int medkitCount = 0;

    /// <summary>
    /// Ensures the player starts with full health.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth); 
        playerHealthBar.SetHealth(currentHealth); 
    }

    /// <summary>
    /// Access (currentHealth) and subtract damage from the current health of the player.
    /// Die when player's health reaches zero
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage) //A function with a parameter 
    {
        currentHealth -= damage;

        // Update current health display. 100
        playerHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Mekit healing system
    /// </summary>
    void UseMedkit()
    {
        if (medkitCount > 0)
        {
            // Increase health but not above maxHealth. Maxhealthh as 2nd argument to not exceed 100.
            currentHealth = Mathf.Min(currentHealth + 5, maxHealth);

            // Update current health display
            playerHealthBar.SetHealth(currentHealth); 

            //Decrement Medkit when it is used
            medkitCount -= 1;
            Debug.Log("Used a medkit. Remaining medkits: " + medkitCount);
        }

        else
        {
            Debug.Log("No medkits left to use.");
        }
    }

    /// <summary>
    /// function to handle the logic of picking up a medkit in your game.
    /// </summary>
    public void AddMedkit()
    {
        medkitCount = medkitCount + 1;
        Debug.Log("Medkit picked up. Total medkits: " + medkitCount);
    }

    /// <summary>
    /// When medkit is at 0, player cannot use MedKit anymore
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && medkitCount > 0)
        {
            UseMedkit();
        }

        if (Input.GetMouseButtonDown(1))
        {
            CheckForButtonPress();
        }
    }

    /// <summary>
    /// Checks for button press and interacts with the correct or wrong answer buttons.
    /// </summary>
    void CheckForButtonPress()
    {
        // Perform sphere-based interaction detection here if needed
        // For simplicity, you can manage interaction directly in this method
    }

    /// <summary>
    /// A UI screen to show other alternatives when player dies
    /// </summary>
    void Die()
    {
        GameManager.Instance.GameOver();
    }

}
