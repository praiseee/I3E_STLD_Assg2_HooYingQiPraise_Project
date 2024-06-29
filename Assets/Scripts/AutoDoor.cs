/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Automatic door script based on player's key count.
 */

using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Animator doorAnim;
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    /// <summary>
    /// set up to trigger the door animations based on the player's key count
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.GetKeyCount() > 0)
            {
                Debug.Log("Player collided with the door and has collected a key.");
                doorAnim.SetTrigger("open");
            }
        }
    }

    /// <summary>
    /// set up to trigger the door animations based on the player's key count.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.GetKeyCount() > 0)
            {
                Debug.Log("Player stopped colliding with the door.");
                doorAnim.SetTrigger("close");
            }
        }
    }
}
