using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Player
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentForm = Form.Water;
        Animator = transform.GetChild(0).GetComponent<Animator>();

    }

  
    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Morph()
    {
        WaterScript.enabled = true;
        AirScript.enabled = false;
        EarthScript.enabled = false;
        FireScript.enabled = false;
        CurrentForm = Form.Water;

    }
}
