/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Enemy AI damage player
 */

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 150;
    public int currentHealth;

    public HealthBar enemyHealthBar;

    public void Damage(int damage)
    {
        currentHealth -= damage;
        enemyHealthBar.SetHealth(currentHealth); //Update the health value displayed on the health bar.

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Enemy current health:" + currentHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //Initializing the player's health to the maximum possible value at the start of the game.
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
