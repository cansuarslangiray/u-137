using UnityEngine;

public class star : MonoBehaviour
{
    public int scoreValue = 10; // Toplanabilir ögenin puan deðeri

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name("Player"))
        {
            Collect(); // Toplanabilir ögeyi topla
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collidedObjectName = collision.gameObject.name;

        if (collidedObjectName == "Player")
        {
            Collect();
            Debug.Log("TargetObject ile çarpýþma gerçekleþti!");
        }
        
    }

    private void Collect()
    {
        // Toplanabilir ögenin toplandýðýnda yapýlacak iþlemler
        GameManager.Instance.IncreaseScore(scoreValue); // Oyun yöneticisine puaný arttýrmasýný söyle

        Destroy(gameObject); // Toplanabilir ögeyi yok et
    }
}
