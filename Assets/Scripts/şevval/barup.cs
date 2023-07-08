using UnityEngine;

public class barup : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    private float originalY; // Baþlangýç pozisyonu
    private bool moveUp = true; // Yukarý mý aþaðý mý hareket ettiðimizi kontrol etmek için bir bayrak

    void Start()
    {
        originalY = transform.position.y; // Baþlangýç pozisyonunu kaydetme
    }

    void Update()
    {
        // Hareket yönünü belirleme
        if (moveUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime); // Yukarý doðru hareket
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime); // Aþaðý doðru hareket
        }

        // Hareket sýnýrýný kontrol etme
        if (transform.position.y >= originalY + 5f) // Yukarý sýnýrý aþarsa
        {
            moveUp = false; // Hareket yönünü aþaðý çevir
        }
        else if (transform.position.y <= originalY - 5f) // Aþaðý sýnýrý aþarsa
        {
            moveUp = true; // Hareket yönünü yukarý çevir
        }
    }
}
