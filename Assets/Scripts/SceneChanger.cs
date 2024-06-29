/*
 * Author: Hoo Ying Qi Praise
 * Date: 23/06/2024
 * Description: Script to handle scene chang
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public int targetscene = 2;

    /// <summary>
    /// Check for collision between player and object for change scene to occur
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(targetscene);
    }
}

