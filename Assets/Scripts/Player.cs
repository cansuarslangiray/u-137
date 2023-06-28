using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float jumpforce = 5.0f;
    private bool resetJumpNeeded = false;
    [SerializeField]
    private float speed=5f;
    private bool grounded = false;
    private SpriteRenderer _spriteRenderer;
   // private PlayerAnimation _playerAnim;

   protected GameObject WaterModel;
   protected Water WaterScript;
   protected GameObject AirModel;
   protected Air AirScript;
   protected GameObject EarthModel;
   protected Earth EarthScript;
   protected GameObject FireModel;
   protected Fire FireScript;
   
   
   public static Form CurrentForm;
   protected bool IsCasting; 

    [SerializeField] private LayerMask _groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
       // _playerAnim = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
       WaterScript = transform.GetComponent<Water>();
       AirScript = transform.GetComponent<Air>();
       EarthScript = transform.GetComponent<Earth>();
       FireScript = transform.GetComponent<Fire>();
       WaterModel = transform.GetChild(0).gameObject;
       AirModel = transform.GetChild(1).gameObject;
       EarthModel = transform.GetChild(2).gameObject;
       FireModel = transform.GetChild(3).gameObject;
       IsCasting = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GetInput();

    }

     protected void Movement()
    {
        grounded = IsGrounded();
        float move = Input.GetAxis("Horizontal");
        Flip(move);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpforce);
            StartCoroutine(ResetJumpNeededRoutine().GetEnumerator());
            //_playerAnim.Jump(true);
        }
        _rigidbody2D.velocity = new Vector2(move*speed, _rigidbody2D.velocity.y);
        //_playerAnim.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (resetJumpNeeded == false)
            {
                //_playerAnim.Jump(false);
                return true;
            }
            
        }

        return false;
    }

    protected void GetInput()
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
    }
    void SwitchToWaterCharacter()
    {
        WaterModel.SetActive(true);
        FireModel.SetActive(false);
        EarthModel.SetActive(false);
        AirModel.SetActive(false);
    }

    void SwitchToFireCharacter()
    {
        WaterModel.SetActive(false);
        FireModel.SetActive(true);
        EarthModel.SetActive(false);
        AirModel.SetActive(false);
    }
    void SwitchToEarthCharacter()
    {
        WaterModel.SetActive(false);
        FireModel.SetActive(false);
        EarthModel.SetActive(true);
        AirModel.SetActive(false);
    }
    void SwitchToAirCharacter()
    {
        WaterModel.SetActive(false);
        FireModel.SetActive(false);
        EarthModel.SetActive(false);
        AirModel.SetActive(true);
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
              _spriteRenderer.flipX = false;
          }else if (move < 0)
          { 
              _spriteRenderer.flipX = true;
          }
                
              
    }
    protected virtual void Morph()
    {
    }

}
