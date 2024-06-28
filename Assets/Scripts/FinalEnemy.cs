/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: FinalEnemy script handling health, damage, and crystal spawning upon death
 */

using UnityEngine;

public class FinalEnemy : MonoBehaviour
{
    public int maxHealth = 150; // Maximum health value for the enemy
    public int currentHealth; // Current health value of the enemy
    public HealthBar enemyHealthBar; // Reference to the HealthBar script for the enemy
    public GameObject crystalPrefab; // Reference to the crystal prefab to spawn upon death
    private GameObject spawnedCrystal; // Reference to the spawned crystal

    /// <summary>
    /// Initializing the enemy's health to the maximum possible value at the start of the game.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
        enemyHealthBar.SetHealth(currentHealth); // Update the health bar to display the current health
    }

    /// <summary>
    /// Logic for handling damage to enemies and health reduction
    /// </summary>
    /// <param name="damage">Amount of damage to apply to the enemy</param>
    public void Damage(int damage)
    {
        currentHealth -= damage;
        enemyHealthBar.SetHealth(currentHealth); // Update the health bar to display the current health

        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("Enemy current health: " + currentHealth);
    }

    /// <summary>
    /// Handle enemy death and spawn a crystal
    /// </summary>
    void Die()
    {
        // Instantiate a crystal at the enemy's position upon death
        spawnedCrystal = Instantiate(crystalPrefab, transform.position, Quaternion.identity);

        // Deactivate the crystal instead of destroying it
        if (spawnedCrystal != null)
        {
            spawnedCrystal.SetActive(false);
        }

        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
