using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// This variable allow us to connect other variables to create custom gun behavior
    /// </summary>
    public UnityEvent OnGunShoot;

    /// <summary>
    /// Number of seconds acting as as a buffer between firing
    /// </summary>
    public float FireCoolDown;

    /// <summary>
    /// Determine it is a semi gun
    /// </summary>
    public bool Automatic;

    /// <summary>
    /// Store current cooldown of weapon
    /// </summary>
    private float CurrentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCooldown = FireCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0))
            {
               if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCoolDown;
                }
            }
        }

        else
        {
            if (Input.GetMouseButton(0))
            { 
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCoolDown;
                }
            }
        }
        CurrentCooldown -= Time.deltaTime;
    }
}
