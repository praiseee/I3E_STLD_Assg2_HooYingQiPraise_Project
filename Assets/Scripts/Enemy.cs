/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Enemy AI damage player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 300;
    public int currentHealth;

    public HealthBar healthBar;

    public void Damage (int damage)
    {
        currentHealth -= damage;    
        healthBar.SetHealth(currentHealth);
        
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
        healthBar.SetMaxHealth(maxHealth);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
