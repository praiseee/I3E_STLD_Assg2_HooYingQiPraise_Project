/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Medkit script for handling medkit pickup and usage
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswerButton : MonoBehaviour
{
    public int damageAmount = 5;

    public void OnInteract()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damageAmount);
        }
    }
}
