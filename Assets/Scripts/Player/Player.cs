using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public enum Form
{
    Water,
    Air,
    Earth,
    Fire
    
}

public class Player : MonoBehaviour
{
    protected Animator Animator;
    protected Rigidbody2D _rigidbody2D;
    [SerializeField]
    public float jumpforce = 15.0f;
    private bool resetJumpNeeded = false;
    [SerializeField]
    private float speed=10f;

    [SerializeField] public float hearth =10f;
    [SerializeField] private Transform fallPoint;
    [SerializeField] private Transform startPoint;


    private SpriteRenderer _spriteRenderer;

    protected GameObject WaterModel;
   protected Water WaterScript;
   protected GameObject AirModel;
   protected Air AirScript;
   protected GameObject EarthModel;
   protected Earth EarthScript;
   protected GameObject FireModel;
   protected Fire FireScript;

    protected bool isWater=false;
    public static Form CurrentForm;
    protected bool IsJumping;
    protected float move;    
    protected float moveV;
    private bool _isFallen;
    

    
    public LayerMask ground;
    public GameObject CameraPoint;
    public GameObject point;



   // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
       WaterScript = transform.GetComponent<Water>();
       AirScript = transform.GetComponent<Air>();
       EarthScript = transform.GetComponent<Earth>();
       FireScript = transform.GetComponent<Fire>();
       WaterModel = transform.GetChild(0).gameObject;
       AirModel = transform.GetChild(1).gameObject;
       EarthModel = transform.GetChild(2).gameObject;
       FireModel = transform.GetChild(3).gameObject;
       IsJumping = false;

    }


     protected void Movement()
    {
        
        move = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        Flip(move);
        //Debug.Log("groundedBefore " + grounded);
       // Debug.Log("ısGrounded "+ IsGrounded());
        //Debug.Log("groundedAfter " + grounded);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpforce);
            StartCoroutine(ResetJumpNeededRoutine().GetEnumerator());
            IsJumping = true;
        }
        if (Mathf.Abs(transform.position.x-point.transform.position.x)< 1 && Input.GetKey(KeyCode.W))
        {
            
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, moveV*15f);
        }
        _rigidbody2D.velocity = new Vector2(move*speed, _rigidbody2D.velocity.y);

    }

   protected bool IsGrounded()
   {
       Vector2 position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hitInfo = Physics2D.Raycast(position, Vector2.down, 0.5f, ground);
        Debug.DrawRay(position,Vector2.down,Color.red);
        if (hitInfo.collider != null)
        {
            if (hitInfo.transform.gameObject.CompareTag("MovingStone"))
            {
                transform.SetParent(hitInfo.transform);
            }
            if (resetJumpNeeded == false)
            {
                IsJumping = false;
                return true;
            }
            
        } else
        {
            transform.SetParent(null);

        }
        
        return false;
    }

    protected  void GetInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToWaterCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToFireCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchToEarthCharacter();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchToAirCharacter();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }
    void SwitchToWaterCharacter()
    {
        WaterModel.SetActive(true);
        FireModel.SetActive(false);
        EarthModel.SetActive(false);
        AirModel.SetActive(false);
        AirScript.enabled = false;
        WaterScript.enabled = true;
        EarthScript.enabled = false;
        FireScript.enabled = false;
        isWater = true;
    }

    void SwitchToFireCharacter()
    {
        WaterModel.SetActive(false);
        FireModel.SetActive(true);
        EarthModel.SetActive(false);
        AirModel.SetActive(false);
        AirScript.enabled = false;
        WaterScript.enabled = false;
        EarthScript.enabled = false;
        FireScript.enabled = true;
        isWater = false;
    }
    void SwitchToEarthCharacter()
    {
        WaterModel.SetActive(false);
        FireModel.SetActive(false);
        EarthModel.SetActive(true);
        AirModel.SetActive(false);
        AirScript.enabled = false;
        WaterScript.enabled = false;
        EarthScript.enabled = true;
        FireScript.enabled = false;
        isWater = false;
    }
    void SwitchToAirCharacter()
    {
        WaterModel.SetActive(false);
        FireModel.SetActive(false);
        EarthModel.SetActive(false);
        AirModel.SetActive(true);
        
        AirScript.enabled = true;
        WaterScript.enabled = false;
        EarthScript.enabled = false;
        FireScript.enabled = false;
        isWater = false;
    }
    
    
    IEnumerable ResetJumpNeededRoutine()
    {
        resetJumpNeeded = true;
        yield return new WaitForSeconds(1.0f);
        resetJumpNeeded = false;
    }

    public void Flip(float move)
    {
          if (move > 0)
          {
              _spriteRenderer.flipX = true;
          }else if (move < 0)
          { 
              _spriteRenderer.flipX = false;
          }
                
              
    }

    protected void PlayerAnimatıon()
    {
        Animator.SetBool("Jumping", IsJumping);
        Animator.SetFloat("Move",Mathf.Abs(move));
    }

    protected void Camera()
    {
        if (Vector2.Distance(transform.position, fallPoint.position)<5)
        {
            _isFallen = true;

        }

        if (Vector2.Distance(transform.position, startPoint.position) < 5)
        {
            _isFallen = false;
        }

        if (_isFallen)
        {
            CameraPoint.transform.position = new Vector3(transform.position.x + 3f,transform.position.y+3f,-10f);

        }
        else 
        {
            CameraPoint.transform.position = new Vector3(transform.position.x + 3f,0f,-10f);

        }

        
    }

    public virtual void Attack()
    {
        
    }
    
    
}
