using UnityEngine;

public class barup : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    private float originalY; // Ba�lang�� pozisyonu
    private bool moveUp = true; // Yukar� m� a�a�� m� hareket etti�imizi kontrol etmek i�in bir bayrak

    void Start()
    {
        originalY = transform.position.y; // Ba�lang�� pozisyonunu kaydetme
    }

    void Update()
    {
        // Hareket y�n�n� belirleme
        if (moveUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime); // Yukar� do�ru hareket
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime); // A�a�� do�ru hareket
        }

        // Hareket s�n�r�n� kontrol etme
        if (transform.position.y >= originalY + 5f) // Yukar� s�n�r� a�arsa
        {
            moveUp = false; // Hareket y�n�n� a�a�� �evir
        }
        else if (transform.position.y <= originalY - 5f) // A�a�� s�n�r� a�arsa
        {
            moveUp = true; // Hareket y�n�n� yukar� �evir
        }
    }
}
