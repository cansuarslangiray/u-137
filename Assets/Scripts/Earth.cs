using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : Player
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentForm = Form.Earth;
        Animator = transform.GetChild(2).GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();
        IsGrounded();
        Movement();
        PlayerAnimatıon();
    }
    
}
