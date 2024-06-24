/*
 * Author: Hoo Ying Qi Praise
 * Date: 24/5/2024
 * Description: Pick Up and Drop system for guns
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public ProjectileGun gunScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float downForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Update()
    {
        /// <summary>
        /// Check if player is in range and that "E" is pressed
        /// </summary>
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E)) PickUp();
    }

    private void PickUp()
    {
        equipped = true;

        /// <summary>
        /// Make RigidBody kinematic and BoxCollider to trigger
        /// </summary>
        rb.isKinematic = true;
        coll.isTrigger = true;

        /// <summary>
        /// Enable Script
        /// </summary>
        gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;

        /// <summary>
        /// Make RigidBody NOT kinematic and BoxCollider to trigger
        /// </summary>
        rb.isKinematic = false;
        coll.isTrigger = false;

        /// <summary>
        /// Disable Script
        /// </summary>
        gunScript.enabled = false;
    }
}
