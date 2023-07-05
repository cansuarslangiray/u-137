using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemy,Idamageable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damge()
    {
        Debug.Log("Damage()");
        Health--;
        anim.SetTrigger("Attack");
        isHit = true;
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
