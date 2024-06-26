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

    public HealthBar playerHealthBar;  // Ensure this is of type HealthBar

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Player has died");
        }
        Debug.Log("Player health:" + currentHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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
