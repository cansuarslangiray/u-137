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
    private void Update()
    {
        Camera();
        GetInput();
        IsGrounded();
        Movement();
        PlayerAnimatıon();
    }
    
    
}
