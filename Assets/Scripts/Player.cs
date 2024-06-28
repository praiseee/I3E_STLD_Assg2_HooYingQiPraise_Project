/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Player script handling health, damage, medkits, keys, and crystals
 */

using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health value for the player
    public int currentHealth; // Current health value of the player
    public HealthBar playerHealthBar; // Reference to the HealthBar script
    private int medkitCount = 0; // Counter for medkits the player has collected
    private int keyCount = 0; // Counter for keys the player has collected
    private int crystalCount = 0; // Counter for crystals the player has collected
    public TMP_Text medkitText; // TextMeshPro text component for medkit count
    public TMP_Text keyText; // TextMeshPro text component for key count
    public TMP_Text crystalText; // TextMeshPro text component for crystal count

    /// <summary>
    /// Ensures the player starts with full health.
    /// </summary>
    void Start()
    {
        // Set the player's health to the maximum health value at the start
        currentHealth = maxHealth;

        // Set the maximum health value on the health bar
        playerHealthBar.SetMaxHealth(maxHealth);

        // Update the health bar to display the current health
        playerHealthBar.SetHealth(currentHealth);

        // Update the initial medkit count display
        UpdateMedkitCountDisplay();

        // Update the initial key count display
        UpdateKeyCountDisplay();

        // Update the initial crystal count display
        UpdateCrystalCountDisplay();
    }

    /// <summary>
    /// Access (currentHealth) and subtract damage from the current health of the player.
    /// Die when player's health reaches zero
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        // Subtract damage from the player's current health
        currentHealth -= damage;

        // Update current health display on the health bar
        playerHealthBar.SetHealth(currentHealth);

        // Check if the player's health has reached zero
        if (currentHealth <= 0)
        {
            // Call the Die method to handle player death
            Die();
        }
    }

    /// <summary>
    /// Medkit healing system
    /// </summary>
    void UseMedkit()
    {
        // Check if the player has any medkits left
        if (medkitCount > 0)
        {
            // Increase health but not above maxHealth
            currentHealth = Mathf.Min(currentHealth + 5, maxHealth);

            // Update current health display on the health bar
            playerHealthBar.SetHealth(currentHealth);

            // Decrement Medkit count when used
            medkitCount--;

            // Update the medkit count display after using a medkit
            UpdateMedkitCountDisplay();

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
        // Increment the medkit count
        medkitCount++;

        // Update the medkit count display after picking up a medkit
        UpdateMedkitCountDisplay();

        Debug.Log("Medkit picked up. Total medkits: " + medkitCount);
    }

    /// <summary>
    /// Function to handle the logic of picking up a key in game.
    /// </summary>
    public void AddKey()
    {
        // Increment the key count
        keyCount++;

        // Update the key count display after picking up a key
        UpdateKeyCountDisplay();

        Debug.Log("Key picked up. Total keys: " + keyCount);
    }

    /// <summary>
    /// Function to handle the logic of picking up a crystal in game.
    /// </summary>
    public void AddCrystal()
    {
        // Increment the crystal count
        crystalCount++;

        // Update the crystal count display after picking up a crystal
        UpdateCrystalCountDisplay();

        Debug.Log("Crystal picked up. Total crystals: " + crystalCount);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Use medkit on key press (e.g., 'F')
        if (Input.GetKeyDown(KeyCode.F) && medkitCount > 0)
        {
            // Call the UseMedkit method to use a medkit
            UseMedkit();
        }

        // Check for button press on right mouse button (Fire2)
        if (Input.GetMouseButtonDown(1))
        {
            // Call the CheckForButtonPress method to check for button press
            CheckForButtonPress();
        }
    }

    /// <summary>
    /// Checks for button press and interacts with correct or wrong answer buttons.
    /// </summary>
    void CheckForButtonPress()
    {
        // Create a RaycastHit variable to store the hit information
        RaycastHit hit;

        // Perform a raycast from the camera to the mouse position
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            // Check if the hit object has a CorrectAnswerButton component
            CorrectAnswerButton correctButton = hit.collider.GetComponent<CorrectAnswerButton>();
            if (correctButton != null)
            {
                // Call the OnButtonPress method of the CorrectAnswerButton
                correctButton.OnButtonPress();
                return;
            }

            // Check if the hit object has a WrongAnswerButton component
            WrongAnswerButton wrongButton = hit.collider.GetComponent<WrongAnswerButton>();
            if (wrongButton != null)
            {
                // Call the OnButtonPress method of the WrongAnswerButton
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
        // Call the GameOver method of the GameManager instance to handle game over
        GameManager.Instance.GameOver();
    }

    /// <summary>
    /// Updates the medkit count display using TextMeshPro.
    /// </summary>
    void UpdateMedkitCountDisplay()
    {
        // Update the TextMeshPro text component to display the current medkit count
        medkitText.text = "Medkits: " + medkitCount.ToString();
    }

    /// <summary>
    /// Updates the key count display using TextMeshPro.
    /// </summary>
    void UpdateKeyCountDisplay()
    {
        // Update the TextMeshPro text component to display the current key count
        keyText.text = "Keys: " + keyCount.ToString();
    }

    /// <summary>
    /// Updates the crystal count display using TextMeshPro.
    /// </summary>
    void UpdateCrystalCountDisplay()
    {
        // Update the TextMeshPro text component to display the current crystal count
        crystalText.text = "Crystals: " + crystalCount.ToString();
    }
}

