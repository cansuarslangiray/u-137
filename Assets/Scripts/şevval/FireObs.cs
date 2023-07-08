using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireObs : Player 
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isFire == true)
        {
            return;
        }
        if (isFire == false)
        {
            if (other.tag == "fireObs")
            {
                SceneManager.LoadScene("Summer");
            }
        }

    }
}
