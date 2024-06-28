using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CorrectAnswerButton : MonoBehaviour
{
    public TMP_Text correctText;
    public List<GameObject> wallsToDestroy = new List<GameObject>(); // List of wall objects to destroy upon correct answer

    /// <summary>
    /// Display the correct message. Hide the message after 1 second and destroy the specified walls.
    /// </summary>
    public void OnButtonPress()
    {
        correctText.gameObject.SetActive(true);
        Invoke("HideCorrectMessage", 1f);

        // Loop through all walls to destroy
        foreach (GameObject wall in wallsToDestroy)
        {
            if (wall != null)
            {
                Destroy(wall);
            }
        }
    }

    void HideCorrectMessage()
    {
        correctText.gameObject.SetActive(false);
    }
}
