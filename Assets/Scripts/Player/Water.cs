using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Player, Idamageable
{

    public GameObject waterEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CurrentForm = Form.Water;
        Animator = transform.GetChild(0).GetComponent<Animator>();

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

    public int Health { get; set; }
    public void Damge()
    {
      
    }

    public override void Attack()
    {
        Animator.SetBool("isAttacking",true);
        Instantiate(waterEffectPrefab, transform.position, Quaternion.identity);
    }
}
