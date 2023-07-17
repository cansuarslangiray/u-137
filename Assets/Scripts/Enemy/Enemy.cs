using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;

    protected SpriteRenderer _sprite;
    protected bool _switch;
    protected Animator anim;

    protected bool isHit = false;

    /*public virtual void Update()
    {
        Movement();
    }*/

    public virtual void Init()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        Init();
    }
    


    public virtual void Attack()
    {
        Debug.Log(this.gameObject.name);
    }
}