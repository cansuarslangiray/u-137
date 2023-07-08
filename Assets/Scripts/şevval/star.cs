using UnityEngine;

public class star : MonoBehaviour
{
    public int scoreValue = 10; // Toplanabilir �genin puan de�eri

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name("Player"))
        {
            Collect(); // Toplanabilir �geyi topla
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collidedObjectName = collision.gameObject.name;

        if (collidedObjectName == "Player")
        {
            Collect();
            Debug.Log("TargetObject ile �arp��ma ger�ekle�ti!");
        }
        
    }

    private void Collect()
    {
        // Toplanabilir �genin topland���nda yap�lacak i�lemler
        GameManager.Instance.IncreaseScore(scoreValue); // Oyun y�neticisine puan� artt�rmas�n� s�yle

        Destroy(gameObject); // Toplanabilir �geyi yok et
    }
}
