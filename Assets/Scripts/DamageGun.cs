/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Damage for Modular Weapon System
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform PlayerCamera;

    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    /// <summary>
    /// Checks for player input to fire the weapon
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    /// <summary>
    /// Casts a ray from the player's camera forward direction (PlayerCamera.forward) to simulate shooting.
    /// </summary>
    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward); //creates a new ray named gunRay, ray starts from the position of the PlayerCamera
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange)) //checks if the ray hits any collider within a maximum distance of BulletRange.
        {
            Entity enemy = hitInfo.collider.gameObject.GetComponent<Entity>(); //GameObject that was hit by the raycast 
            if (enemy != null)
            {
                enemy.CurrentHealth -= Damage; //hit GameObject, this line reduces its CurrentHealth
                Debug.Log("Shot entity, new health: " + enemy.CurrentHealth); //check that an enemy was shot
            }
        }
    }
}
