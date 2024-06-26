/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Player script handling health and damage
 */

using UnityEngine;
public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar playerHealthBar;

    void Start()
    {
        currentHealth = maxHealth;
        playerHealthBar.SetMaxHealth(maxHealth); // Initialize max health
        playerHealthBar.SetHealth(currentHealth); // Initialize current health display
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
}
