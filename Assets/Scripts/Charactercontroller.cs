using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour
{
    public float speed = 0.0f;
    private Rigidbody2D r2d;
    private Animator _animator;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            speed = 1.0f;
        }
        else
        {
            speed = 0.0f;
        }
        _animator.SetFloat("speed", speed);
        r2d.velocity = new Vector2(x: speed, y: 0f);
    }
}
