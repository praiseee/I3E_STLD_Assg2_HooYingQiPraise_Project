/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Handle trigger points to trigger popup canvas and pause the game.
 */

using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField]
    private int popupIndex = 0;  // Index of the popup canvas in GameManager's popupCanvases list

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TriggerPopup(popupIndex);
        }
    }
}



