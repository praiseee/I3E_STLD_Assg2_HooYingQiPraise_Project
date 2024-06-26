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
        enemyHealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Enemy current health:" + currentHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
