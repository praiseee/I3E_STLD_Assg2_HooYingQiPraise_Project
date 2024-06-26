/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Script for handling correct answer button interaction
 */

using UnityEngine;
using TMPro;

public class CorrectAnswerButton : MonoBehaviour
{
    public TMP_Text correctText;

    /// <summary>
    /// Display the correct message. Hide the message after 5 seconds
    /// </summary>
    public void OnButtonPress()
    {
        correctText.gameObject.SetActive(true);
        Invoke("HideCorrectMessage", 1f); 
    }

    void HideCorrectMessage()
    {
        correctText.gameObject.SetActive(false);
    }
}
