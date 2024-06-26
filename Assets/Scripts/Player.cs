/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: HealthBar
 */

using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar playerHealthBar;  

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth); //Update the health value displayed on the health bar.

        if (currentHealth <= 0)
        {
            Debug.Log("Player has died");
        }
        Debug.Log("Player health:" + currentHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //Initializing the player's health to the maximum possible value at the start of the game.
        playerHealthBar.SetMaxHealth(maxHealth); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }
}
