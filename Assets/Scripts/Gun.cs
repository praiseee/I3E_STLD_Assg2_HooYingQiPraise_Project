/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Modular Weapon System
 */

using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;

    public float FireCoolDown;
    private float CurrentCooldown;

    /// <summary>
    /// Reference to DamageGun script
    /// </summary>
    private DamageGun damageGun;

    /// <summary>
    /// AudioSource 
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// AudioClip for shooting sound
    /// </summary>
    public AudioClip shootingSound;

    /// <summary>
    /// Initialize gun and its components
    /// </summary>
    void Start()
    {
        CurrentCooldown = FireCoolDown;
        damageGun = GetComponent<DamageGun>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CurrentCooldown <= 0f)
        {
            OnGunShoot?.Invoke(); //Invoke the event without throwing a null reference 
            CurrentCooldown = FireCoolDown; //resets CurrentCooldown to the value of FireCoolDown

            // Play the shooting sound
            if (shootingSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootingSound);
            }
        }

        CurrentCooldown -= Time.deltaTime; //the cooldown is decremented by the time that has passed since the last frame 
    }

    /// <summary>
    /// Method to handle shooting actions
    /// </summary>
    public void OnShoot()
    {
        damageGun.Shoot();
    }
}
