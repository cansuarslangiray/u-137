using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int collectedObjects = 0; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Çarpýþma algýlandýðýnda
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

        // Toplanan nesne sayýsýný artýr
        collectedObjects++;

        // Toplanan nesne sayýsýný güncelle
        UpdateCollectedObjectCount();
    }

    private void UpdateCollectedObjectCount()
    {
        // Toplanan nesne sayýsýný ekranda güncelle
        Debug.Log("Toplanan Nesne Sayýsý: " + collectedObjects);
    }
}
