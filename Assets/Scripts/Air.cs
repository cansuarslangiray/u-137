using System;
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

    private void Update()
    {
        Camera();
        GetInput();
        IsGrounded();
        Movement();
        PlayerAnimatıon();
       
    }
    // Update is called once per frame
    
}
