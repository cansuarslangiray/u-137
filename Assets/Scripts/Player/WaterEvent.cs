using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEvent : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
       // Light();

    }

    /*public void Light()
    {
        Debug.Log("water should light");
        if (_water.transform.GetComponent<SpriteRenderer>().flipX == true)
        {
            _sprite.flipX = true;
        }
        else if (_water.transform.GetComponent<SpriteRenderer>().flipX = false)
        {
            _sprite.flipX = false;
        }
        //_water.Attack();
    }*/
}