/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Behaviour of Enemy Projectiles, bullets
 */

using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 2;

    /// <summary>
    /// GameObject move forward at a constant speed.
    /// </summary>
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    /// <summary>
    /// Detect collision with player and apply damage
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
