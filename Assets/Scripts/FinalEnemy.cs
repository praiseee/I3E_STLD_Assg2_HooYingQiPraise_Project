/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Handling health, damage, and crystal spawning upon death
 */

using UnityEngine;

public class FinalEnemy : MonoBehaviour
{
    public int maxHealth = 150; 
    public int currentHealth; 
    public HealthBar enemyHealthBar; 
    public GameObject crystalPrefab; 
    private GameObject spawnedCrystal; 

    /// <summary>
    /// Start the enemy's health to the max  value at the start of the game.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
        enemyHealthBar.SetHealth(currentHealth); // Update health bar to display current health
    }

    /// <summary>
    /// Damage to enemies and health reduction
    /// </summary>
    /// <param name="damage">Amount of damage to apply to the enemy</param>
    public void Damage(int damage)
    {
        currentHealth -= damage;
        enemyHealthBar.SetHealth(currentHealth); // Update health bar to display the current health

        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("Enemy current health: " + currentHealth);
    }

    /// <summary>
    /// Enemy ddeath and spawn crystal
    /// </summary>
    void Die()
    {
        // Instantiate a crystal at the enemy's position upon death
        spawnedCrystal = Instantiate(crystalPrefab, transform.position, Quaternion.identity);

        if (spawnedCrystal != null)
        {
            spawnedCrystal.SetActive(false);
        }

        Destroy(gameObject);
    }
}
