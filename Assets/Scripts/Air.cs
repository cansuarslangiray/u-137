using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Air : Player
{
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentForm = Form.Air;
        Animator = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
 

    protected override void Morph()
    {
            WaterScript.enabled = false;
            AirScript.enabled = true;
            EarthScript.enabled = false;
            FireScript.enabled = false;
            CurrentForm = Form.Air;
        
        
    }
}
