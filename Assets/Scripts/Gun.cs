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

    // Start is called before the first frame update
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
            OnGunShoot?.Invoke();
            CurrentCooldown = FireCoolDown;
        }

        CurrentCooldown -= Time.deltaTime;
    }


    public void OnShoot()
    {
        damageGun.Shoot();

    }
}
