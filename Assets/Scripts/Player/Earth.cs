using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "Autumn")
        {
            AutumnCamera();
        }
        if (SceneManager.GetActiveScene().name == "Winter")
        {
            WinterCamera();
        }  
        GetInput();
        IsGrounded();
        Movement();
        PlayerAnimatıon();
    }
    
}
