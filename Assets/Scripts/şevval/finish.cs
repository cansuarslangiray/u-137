using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collidedObjectName = collision.gameObject.name;

        if (collidedObjectName == "Player")
        {
            SceneManager.LoadScene(0);
           
        }

    }
}
