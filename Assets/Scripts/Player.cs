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
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Update current health display
        playerHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Medkit healing system
    /// </summary>
    void UseMedkit()
    {
        if (medkitCount > 0)
        {
            // Increase health but not above maxHealth
            currentHealth = Mathf.Min(currentHealth + 5, maxHealth);

            // Update current health display
            playerHealthBar.SetHealth(currentHealth);

            // Decrement Medkit count when used
            medkitCount--;
            Debug.Log("Used a medkit. Remaining medkits: " + medkitCount);
        }
        else
        {
            Debug.Log("No medkits left to use.");
        }
    }

    /// <summary>
    /// Function to handle the logic of picking up a medkit in your game.
    /// </summary>
    public void AddMedkit()
    {
        medkitCount++;
        Debug.Log("Medkit picked up. Total medkits: " + medkitCount);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Use medkit on key press (e.g., 'F')
        if (Input.GetKeyDown(KeyCode.F) && medkitCount > 0)
        {
            UseMedkit();
        }

        // Check for button press on right mouse button (Fire2)
        if (Input.GetMouseButtonDown(1))
        {
            CheckForButtonPress();
        }
    }

    /// <summary>
    /// Checks for button press and interacts with correct or wrong answer buttons.
    /// </summary>
    void CheckForButtonPress()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            CorrectAnswerButton correctButton = hit.collider.GetComponent<CorrectAnswerButton>();
            if (correctButton != null)
            {
                correctButton.OnButtonPress();
                return;
            }

            WrongAnswerButton wrongButton = hit.collider.GetComponent<WrongAnswerButton>();
            if (wrongButton != null)
            {
                wrongButton.OnButtonPress();
                return;
            }
        }
    }

    /// <summary>
    /// Handle player death
    /// </summary>
    void Die()
    {
        GameManager.Instance.GameOver();
    }
}
