/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Modular Weapon System
 */

using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// This variable allows us to connect other variables to create custom gun behavior
    /// </summary>
    public UnityEvent OnGunShoot;

    /// <summary>
    /// Number of seconds acting as a buffer between firing
    /// </summary>
    public float FireCoolDown;

    /// <summary>
    /// Store current cooldown of the weapon
    /// </summary>
    private float CurrentCooldown;

    private DamageGun damageGun;

    /// <summary>
    /// checks if the left mouse button is held down. Checks if the current cooldown of the weapon is less than or equal to zero.
    /// </summary>
    void Start()
    {
        CurrentCooldown = FireCoolDown;
        damageGun = GetComponent<DamageGun>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && CurrentCooldown <= 0f)
        {
            OnGunShoot?.Invoke(); //Invoke the event without throwing a null reference 
            CurrentCooldown = FireCoolDown; // resets CurrentCooldown to the value of FireCoolDown
        }

        CurrentCooldown -= Time.deltaTime; //the cooldown is decremented by the time that has passed since the last frame 
    }


    public void OnShoot()
    {
        damageGun.Shoot();

    }
}
