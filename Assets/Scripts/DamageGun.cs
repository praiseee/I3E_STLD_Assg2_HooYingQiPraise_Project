/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Damage for Modular Weapon System
 */

using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float Damage;
    public float BulletRange;
    private Transform PlayerCamera;

    /// <summary>
    /// Initialize the player camera
    /// </summary>
    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    /// <summary>
    /// Casts a ray from the player's camera forward direction (PlayerCamera.forward)
    /// </summary>
    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward); // Creates a new ray, ray starts from the position of the PlayerCamera
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange)) // Checks if the ray hits any collider within a maximum distance of BulletRange
        {
            Enemy enemy = hitInfo.collider.gameObject.GetComponent<Enemy>(); // GameObject that was hit by raycast 
            if (enemy != null)
            {
                enemy.Damage((int)Damage); // Reduces its CurrentHealth
                Debug.Log("Shot entity, new health: " + enemy.currentHealth);
            }
        }
    }
}
