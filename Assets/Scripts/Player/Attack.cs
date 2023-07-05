using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hit" + col.name);
        Idamageable hit = col.GetComponent<Idamageable>();

        if (hit != null)
        {
            if (_canDamage == true)
            {
                hit.Damge();
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}