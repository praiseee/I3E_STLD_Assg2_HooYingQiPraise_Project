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

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming left mouse button or a similar input
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            Entity enemy = hitInfo.collider.gameObject.GetComponent<Entity>();
            if (enemy != null)
            {
                enemy.CurrentHealth -= Damage;
                Debug.Log("Shot entity, new health: " + enemy.CurrentHealth);
            }
        }
    }
}
