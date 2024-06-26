/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Enemy script handling health, damage
 */

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 150;
    public int currentHealth;

    public HealthBar enemyHealthBar;

    /// <summary>
    /// Logic for handling damage to enemies and health reduction
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        currentHealth = currentHealth - damage;
        enemyHealthBar.SetHealth(currentHealth); //Update the health value displayed on the health bar.

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Enemy current health:" + currentHealth);
    }

    /// <summary>
    /// Initializing the player's health to the maximum possible value at the start of the game.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }
}
