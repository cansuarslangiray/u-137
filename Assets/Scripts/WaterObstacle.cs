using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : Player
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isWater==true)
        {
            return;
        }
        if (isWater == false)
        {
            if (other.tag == "waterObs")
            {
                SceneManager.LoadScene("Summer");
            }
        }

    }
}
