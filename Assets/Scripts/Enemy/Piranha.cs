using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : Enemy
{
    public int Health { get; set; }
    [SerializeField] private bool isAttacking = false;


    public override void Init()
    {
        base.Init();
        Health = base.health;
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Player player = col.transform.GetComponent<Player>();
            if (player != null)
            {
                Attack();
                player.Damage();
                isAttacking = false;
            }
        }
    }

    public void Attack()
    {
        isAttacking = true;
        anim.SetBool("isAttacking", isAttacking);
    }

 
}