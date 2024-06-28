using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [SerializeField]
    private GameObject collectibleToSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with the gift box.");
            SpawnCollectible();
            Destroy(gameObject);
        }
    }

    void SpawnCollectible()
    {
        Debug.Log("Spawning collectible at position: " + transform.position);
        Instantiate(collectibleToSpawn, transform.position, collectibleToSpawn.transform.rotation);
    }
}
