/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: AutoDoor script handling automatic door behavior based on player key count
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Animator doorAnim;
    private Player player; // Reference to the Player script

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player != null && player.GetKeyCount() > 0)
            {
                Debug.Log("Player collided with the door and has collected a key.");
                doorAnim.SetTrigger("open");
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player != null && player.GetKeyCount() > 0)
            {
                Debug.Log("Player stopped colliding with the door.");
                doorAnim.SetTrigger("close");
            }
        }
    }
}
