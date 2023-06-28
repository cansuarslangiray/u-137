using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Player
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentForm = Form.Fire;
        Animator = transform.GetChild(3).GetComponent<Animator>();
    }

    // Update is called once per frame
    

    protected override void Morph()
    {
        WaterScript.enabled = false;
        AirScript.enabled = false;
        EarthScript.enabled = false;
        FireScript.enabled = true;
        CurrentForm = Form.Fire;

    }
}
