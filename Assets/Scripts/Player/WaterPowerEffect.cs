using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WaterPowerEffect : MonoBehaviour
{
    private Vector3 _startPosition;
    private WaterEvent _waterEvent;
    [FormerlySerializedAs("_waterSprite")] public SpriteRenderer waterSprite;
    private bool _isLeft;
    private SpriteRenderer _sprite;

    private void Start()
    {
        Destroy(this.gameObject, 5.0f);
        _startPosition = transform.position;
        _waterEvent = GetComponent<WaterEvent>();
        waterSprite = GameObject.Find("Water").GetComponent<SpriteRenderer>();
        _sprite = GetComponent<SpriteRenderer>();
        Flip();
        
    }

    private void Update()
    {
        
        if (_isLeft==false)
        {
            
            transform.Translate(Vector3.right * 3 * Time.deltaTime);

        }
        else if (_isLeft== true)
        {
            transform.Translate(Vector3.left * 3 * Time.deltaTime);

        }
        RangeCheck();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Idamageable hit = col.GetComponent<Idamageable>();

            if (hit != null)
            {
                hit.Damge();
                Destroy(this.gameObject);
            }
        }
    }

    private void RangeCheck()
    {
        if (Vector2.Distance(transform.position, _startPosition) > 20f)
        {
            Destroy(this.gameObject);
        }
    }

    protected void Flip()
    {
        if (waterSprite.flipX == false)
        {
            _sprite.flipX = true;
            _isLeft = true;

        }
        else if (waterSprite.flipX == true)
        {
            _sprite.flipX = false;
            _isLeft = false;

        }
    }
    
}