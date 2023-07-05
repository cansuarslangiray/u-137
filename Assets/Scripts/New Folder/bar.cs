using UnityEngine;

public class bar : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    private float originalX; // Ba�lang�� pozisyonu
    private bool moveRight = true; // Sa�a hareket edip etmedi�imizi kontrol etmek i�in bir bayrak

    void Start()
    {
        originalX = transform.position.x; // Ba�lang�� pozisyonunu kaydetme
    }

    void Update()
    {
        // Hareket y�n�n� belirleme
        if (moveRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // Sa�a do�ru hareket
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // Sola do�ru hareket
        }

        // Hareket s�n�r�n� kontrol etme
        if (transform.position.x >= originalX + 5f) // Sa� s�n�r� a�arsa
        {
            moveRight = false; // Hareket y�n�n� sola �evir
        }
        else if (transform.position.x <= originalX - 5f) // Sol s�n�r� a�arsa
        {
            moveRight = true; // Hareket y�n�n� sa�a �evir
        }
    }
}
