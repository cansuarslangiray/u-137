using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] public float jumpforce = 15.0f;
    private bool resetJumpNeeded = false;
    [SerializeField] private float speed = 10f;

    [SerializeField] public float hearth = 10f;
    private Transform _fallPoint;
    private Transform _startPoint;
    private Transform _undergroundPoint;


    private SpriteRenderer _spriteRenderer;
    private AutumnPoints _autumnPoints;
    protected GameObject WaterModel;
    protected Water WaterScript;
    protected GameObject AirModel;
    protected Air AirScript;
    protected GameObject EarthModel;
    protected Earth EarthScript;
    protected GameObject FireModel;
    protected Fire FireScript;

    protected bool isWater = false;
    protected bool isFire = false;
    public static Form CurrentForm;
    protected bool IsJumping;
    protected float move;
    protected float moveV;
    private bool _isFallen;
    private bool _isUnderground = false;
    private bool _isStartPoint = false;


    public LayerMask ground;
    public GameObject CameraPoint;
    private Transform _ladderPoint;


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
        if (SceneManager.GetActiveScene().name == "Autumn")
        {
            
            _autumnPoints = GameObject.Find("Points").GetComponent<AutumnPoints>();
            _fallPoint = _autumnPoints.fallPoint;
            _startPoint = _autumnPoints.startPoint;
            _undergroundPoint = _autumnPoints.undergroundPoint;
            _ladderPoint = _autumnPoints.ladderPoint;
        }

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

        if (Mathf.Abs(transform.position.x - _ladderPoint.transform.position.x) < 0.5 && Input.GetKey(KeyCode.W) &&
            Mathf.Abs(transform.position.y - _ladderPoint.transform.position.y) < 7)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, moveV * 10f);
        }

        _rigidbody2D.velocity = new Vector2(move * speed, _rigidbody2D.velocity.y);
    }

    protected bool IsGrounded()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        RaycastHit2D hitInfo = Physics2D.Raycast(position, Vector2.down, 0.7f, ground);
        Debug.DrawRay(position, Vector2.down/2, Color.red);
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
        }
        else
        {
            transform.SetParent(null);
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
        isFire = false;
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
        isFire = true;
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
        isFire = false;
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
        isFire = false;
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
        }
        else if (move < 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    protected void PlayerAnimatıon()
    {
        Animator.SetBool("Jumping", IsJumping);
        Animator.SetFloat("Move", Mathf.Abs(move));
    }

    protected void Camera()
    {
        if (Vector2.Distance(transform.position, _fallPoint.position) < 5)
        {
            _isFallen = true;
            _isUnderground = false;
            _isStartPoint = false;
        }

        if (Vector2.Distance(transform.position, _startPoint.position) < 5)
        {
            _isStartPoint = true;
            _isFallen = false;
            _isUnderground = false;
        }

        if (Vector2.Distance(transform.position, _undergroundPoint.position) < 5)
        {
            _isFallen = false;
            _isUnderground = true;
            _isStartPoint = false;
        }

        if (Vector2.Distance(transform.position, _ladderPoint.transform.position) < 2)
        {
            _isFallen = true;
            _isStartPoint = false;
            _isUnderground = false;
        }

        if (_isFallen)
        {
            CameraPoint.transform.position = new Vector3(transform.position.x + 3f, transform.position.y + 3f, -10f);
        }
        else if (_isStartPoint)
        {
            CameraPoint.transform.position = new Vector3(transform.position.x + 3f, 0f, -10f);
        }
        else if (_isUnderground)
        {
            CameraPoint.transform.position = new Vector3(transform.position.x + 3f, -16.0f, -10f);
        }
    }

    public virtual void Attack()
    {
    }
}