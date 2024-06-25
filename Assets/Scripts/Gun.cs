/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Modular Weapon System
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

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
    /// Determine if it is an automatic gun
    /// </summary>
    public bool Automatic;

    /// <summary>
    /// Store current cooldown of the weapon
    /// </summary>
    private float CurrentCooldown;

    private DamageGun damageGun;

    /// <summary>
    /// checks if the left mouse button is currently being held down. Checks if the current cooldown of the weapon is less than or equal to zero.
    /// </summary>
    void Start()
    {
        CurrentCooldown = FireCoolDown;
        damageGun = GetComponent<DamageGun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && CurrentCooldown <= 0f)
        {
            OnGunShoot?.Invoke(); //syntax is used to safely invoke the event without throwing a null reference exception if it is not subscribed to.
            CurrentCooldown = FireCoolDown; // resets the CurrentCooldown to the value of FireCoolDown
        }

        CurrentCooldown -= Time.deltaTime; //the cooldown is decremented by the time that has passed since the last frame 
    }


    public void OnShoot()
    {
        damageGun.Shoot();

    }
}
