/*
 * Author: Hoo Ying Qi Praise
 * Date: 24/5/2024
 * Description: Pick Up and Drop system for guns
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Polybrush;

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

    private void Start()
    {
        /// <summary>
        /// SetUp
        /// </summary>
        
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
        }
    }

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
        /// Make weapon a child of the camera and move it to default position
        /// </summary>
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

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
        /// Set parent to null
        /// </summary>
        transform.SetParent(null);


        /// <summary>
        /// Make RigidBody NOT kinematic and BoxCollider to normal
        /// </summary>
        rb.isKinematic = false;
        coll.isTrigger = false;

        /// <summary>
        /// Gun carries momentum of player
        /// </summary>
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        /// <summary>
        /// Disable Script
        /// </summary>
        gunScript.enabled = false;
    }
}
