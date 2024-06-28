/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Enemy script handling health, damage, and crystal activation upon death
 */

using UnityEngine;

public class FinalEnemy : MonoBehaviour
{
    public int maxHealth = 150;
    public int currentHealth;

    public HealthBar enemyHealthBar;
    public GameObject crystalPrefab;

    /// <summary>
    /// Damage to enemies and health reduction
    /// </summary>
    /// <param name="damage">Amount of damage to apply to the enemy</param>
    public void Damage(int damage)
    {
        currentHealth = currentHealth - damage;
        enemyHealthBar.SetHealth(currentHealth); // Update the health value displayed on the health bar.

        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("Enemy current health: " + currentHealth);
    }

    /// <summary>
    /// Set the enemy's health to the maximum value at the start of the game.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);

        // Ensure the crystal is inactive at the start
        if (crystalPrefab != null)
        {
            crystalPrefab.SetActive(false);
        }
    }

    /// <summary>
    /// Enemy death and activation of the crystal
    /// </summary>
    void Die()
    {
        // Activate the crystal when the enemy dies
        if (crystalPrefab != null)
        {
            crystalPrefab.transform.position = transform.position;
            crystalPrefab.SetActive(true);
        }

        Destroy(gameObject);
    }
}
