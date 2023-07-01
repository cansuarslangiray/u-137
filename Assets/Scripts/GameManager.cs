using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int collectedObjects = 0; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �arp��ma alg�land���nda
        if (other.CompareTag("Collectible"))
        {
            // Toplanabilir bir nesneyse
            CollectObject(other.gameObject);
        }
    }

    private void CollectObject(GameObject collectible)
    {
        // Nesneyi topla
        Destroy(collectible);

        // Toplanan nesne say�s�n� art�r
        collectedObjects++;

        // Toplanan nesne say�s�n� g�ncelle
        UpdateCollectedObjectCount();
    }

    private void UpdateCollectedObjectCount()
    {
        // Toplanan nesne say�s�n� ekranda g�ncelle
        Debug.Log("Toplanan Nesne Say�s�: " + collectedObjects);
    }
}
