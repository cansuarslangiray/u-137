using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class testere : MonoBehaviour
{
    public GameObject LoseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collidedObjectName = collision.gameObject.name;

        if (collidedObjectName == "Player")
        {
            LoseUI.SetActive(true);
            
        }

    }
}
