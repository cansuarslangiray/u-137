using System;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;


public class PlayerMovement : NetworkBehaviour
{
    private NetworkTransform networkTransform;
    private Vector3 previousPosition;
    private Vector3 moveDir;
    private float distanceThreshold = 0f;
    private Rigidbody2D _rigidbody2D;
    private float moveSpeed;
    private float jumpForce;
    private float distance;
    public GameObject target;

    /* public override void OnNetworkSpawn()
     {
         if (IsLocalPlayer)
         {
             Move(); 
         }
     }*/


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        moveSpeed = 3f;
        jumpForce = 10f;


        GameManager.players.Add(this.gameObject);
        //moveDir = GameManager.players[0].transform.position;
        target = this.gameObject;

        /*if (GameManager.players.Count == 2)
        {
            previousPosition = GameManager.players[1].transform.position;
            distanceThreshold = moveDir.x - previousPosition.x;
        }*/

        if (distanceThreshold < 0f)
        {
            distanceThreshold *= -1f;
        }
    }

    public void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // Get the horizontal input (-1 to 1)
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 movement = new Vector2(moveX * moveSpeed, _rigidbody2D.velocity.y);


        if (distance >= 5)
        {
            if (moveX >= 0.1)
            {
                if (transform.position.x>target.transform.position.x)
                {
                    moveSpeed = 0f;
                   
                }
                else
                {
                    moveSpeed = 3f;
                }
            }

            if (moveX <= -0.1f)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    moveSpeed = 0f;
                }
                else
                {
                    moveSpeed = 3f;
                }
            }
        }
        else
        {
            moveSpeed = 3f;
        }

        _rigidbody2D.velocity = movement;
        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }


    /*private void Update()
    {

        if (GameManager.players.Count== 1)
        {
            if (Input.GetKey(KeyCode.A)) moveDir.x = 1f;
            if (Input.GetKey(KeyCode.D)) moveDir.x = 1f;
        }
        else
        {
            
            if (Input.GetKey(KeyCode.A))
            {
                if (distanceThreshold < 5f)
                {
                    moveDir.x = 1f;
                    distanceThreshold += 1;
                }
                        
                else
                {
                    if (moveDir.x >= previousPosition.x)
                    {
                        distanceThreshold -= 1f;
                        moveDir.x = 1f;
                        
                    }
                    else
                    {
                        moveDir.x = 0.5f;
                        previousPosition.x = 0.5f; 
                    }
                            
                            
                }
                 

            }


            if (Input.GetKey(KeyCode.D))
            {
                if (distanceThreshold < 5f)
                {
                    moveDir.x = 1f;
                    distanceThreshold += 1;
                }
                else
                {
                    if (moveDir.x <= previousPosition.x)
                    {
                        distanceThreshold -= 1f;
                        moveDir.x = 1f;
                       
                    }
                    else
                    {
                        moveDir.x = 0.5f;
                        previousPosition.x = 0.5f;
                    }
                    
                }
            }
        }
            //float jump = Input.GetAxis("Vertical");
            //if (Input.GetKeyDown(KeyCode.W)) moveDir.y = +5f*jump;
            float move = Input.GetAxis("Horizontal");
            float moveSpeed = 3f;
            transform.position += moveDir * moveSpeed * Time.deltaTime*move;

        }*/
}