using UnityEngine;

public class bar : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    private float originalX; // Baþlangýç pozisyonu
    private bool moveRight = true; // Saða hareket edip etmediðimizi kontrol etmek için bir bayrak

    void Start()
    {
        originalX = transform.position.x; // Baþlangýç pozisyonunu kaydetme
    }

    void Update()
    {
        // Hareket yönünü belirleme
        if (moveRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // Saða doðru hareket
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // Sola doðru hareket
        }

        // Hareket sýnýrýný kontrol etme
        if (transform.position.x >= originalX + 5f) // Sað sýnýrý aþarsa
        {
            moveRight = false; // Hareket yönünü sola çevir
        }
        else if (transform.position.x <= originalX - 5f) // Sol sýnýrý aþarsa
        {
            moveRight = true; // Hareket yönünü saða çevir
        }
    }
}
