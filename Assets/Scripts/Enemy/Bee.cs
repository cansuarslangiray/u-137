using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemy,Idamageable
{
    public int Health { get; set; }
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected int speed;

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public virtual void Update()
    {
        Movement();
    }

    public void Damge()
    {
        Debug.Log("Damage()");
        Health--;
        isHit = true;
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
    public  void Movement()
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player player = col.transform.GetComponent<Player>();
            player.Damage();
        }
    }
}
