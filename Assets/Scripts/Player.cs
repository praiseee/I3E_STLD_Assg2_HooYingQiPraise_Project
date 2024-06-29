/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Player script handling health, damage, medkits, keys, and crystals
 */

using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar playerHealthBar;
    private int medkitCount = 0;
    public TMP_Text medkitText;
    public TMP_Text keyText;
    public TMP_Text crystalText;
    public TMP_Text healMessageText;

    /// <summary>
    /// Ensures the player starts with full health.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth);
        playerHealthBar.SetHealth(currentHealth);

        // Initialize key and crystal counts from GameManager
        UpdateMedkitCountDisplay();
        UpdateKeyCountDisplay();
        UpdateCrystalCountDisplay();
    }

    /// <summary>
    /// Access (currentHealth) and subtract damage from the current health of the player.
    /// Die when player's health reaches zero
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
            currentHealth = Mathf.Min(currentHealth + 5, maxHealth);
            playerHealthBar.SetHealth(currentHealth);
            medkitCount--;
            UpdateMedkitCountDisplay();
            DisplayHealMessage(); // Display heal message
            Debug.Log("Used a medkit. Remaining medkits: " + medkitCount);
        }
        else
        {
            Debug.Log("No medkits left to use.");
        }
    }

    /// <summary>
    /// Function to handle the logic of picking up a medkit in your game, Increment the medkit count
    /// </summary>
    public void AddMedkit()
    {
        medkitCount++;
        UpdateMedkitCountDisplay();
        Debug.Log("Medkit picked up. Total medkits: " + medkitCount);
    }

    /// <summary>
    /// Function to handle the logic of picking up a key in game.
    /// </summary>
    public void AddKey()
    {
        GameManager.Instance.AddKey();
        UpdateKeyCountDisplay();
        Debug.Log("Key picked up. Total keys: " + GameManager.Instance.GetKeyCount());
    }

    /// <summary>
    /// Function to handle the logic of picking up a crystal in game.
    /// </summary>
    public void AddCrystal()
    {
        GameManager.Instance.AddCrystal();
        UpdateCrystalCountDisplay();
        Debug.Log("Crystal picked up. Total crystals: " + GameManager.Instance.GetCrystalCount());
    }

    /// <summary>
    /// Use Medkit, Check for button
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

    /// <summary>
    /// Updates the medkit count display using TextMeshPro.
    /// </summary>
    void UpdateMedkitCountDisplay()
    {
        medkitText.text = "Medkits: " + medkitCount.ToString();
    }

    /// <summary>
    /// Updates the key count display using TextMeshPro.
    /// </summary>
    void UpdateKeyCountDisplay()
    {
        keyText.text = "Keys: " + GameManager.Instance.GetKeyCount().ToString();
    }

    /// <summary>
    /// Updates the crystal count display using TextMeshPro.
    /// </summary>
    void UpdateCrystalCountDisplay()
    {
        crystalText.text = "Crystals: " + GameManager.Instance.GetCrystalCount().ToString();
    }

    /// <summary>
    /// Display the message when a medkit is used to heal.
    /// </summary>
    void DisplayHealMessage()
    {
        healMessageText.gameObject.SetActive(true);
        Invoke("HideHealMessage", 2f); // Hide message after 2 seconds
    }

    /// <summary>
    /// Hide the heal message.
    /// </summary>
    void HideHealMessage()
    {
        healMessageText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Get the current key count of the player.
    /// </summary>
    /// <returns>The number of keys the player has collected</returns>
    public int GetKeyCount()
    {
        return GameManager.Instance.GetKeyCount();
    }

    /// <summary>
    /// Get the current crystal count of the player.
    /// </summary>
    /// <returns>The number of crystals the player has collected</returns>
    public int GetCrystalCount()
    {
        return GameManager.Instance.GetCrystalCount();
    }
}
