using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
