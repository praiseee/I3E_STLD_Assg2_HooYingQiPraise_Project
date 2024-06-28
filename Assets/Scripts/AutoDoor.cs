using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Animator doorAnim;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetTrigger("open");
        }
    }

    void onTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            doorAnim.SetTrigger("close");
    }
}
