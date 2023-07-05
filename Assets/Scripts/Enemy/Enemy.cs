using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform pointA, pointB;
    protected SpriteRenderer _sprite;
    protected bool _switch;
    protected Animator anim;

    protected bool isHit = false;

    public virtual void Update()
    {
        Movement();
    }

    public virtual void Init()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Movement()
    {
        if (transform.position == pointA.position)
        {
            Debug.Log("PointA");
            _switch = false;
        }
        else if (transform.position == pointB.position)
        {
            Debug.Log("PointB");
            _switch = true;
        }

        if (_switch == false)
        {
            if (isHit == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            }

            //move right
            _sprite.flipX = false;
        }
        else if (_switch == true)
        {
            //mover left
            if (isHit == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            }

            _sprite.flipX = true;
        }
    }


    public virtual void Attack()
    {
        Debug.Log(this.gameObject.name);
    }
}