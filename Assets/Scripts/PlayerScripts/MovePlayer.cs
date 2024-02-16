using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _forgeJamp;
    [SerializeField] private Transform _checkGroundPosihon;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _wallLayer;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerHealf _playerHealf;
    private bool _rotate = true;

    /*[HideInInspector] */public float DirX;
    [HideInInspector] public float Direchion = 1;

    void Start()
    {
        RunButtonUp();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerHealf = GetComponent<PlayerHealf>();
    }

    void Update()
    {
        _animator.SetBool("IsGrounded", ChackGround());
        _animator.SetFloat("AirFlySpeed", _rb.velocity.y);

        if (_playerHealf.Block)
        {
            Run();
        }
        else
            DirX = 0;
    }

    public void RunButoonDown(float DirXXX)
    {
        DirX = DirXXX;
        Run();
    }

    public void RunButtonUp()
    {
        DirX = 0;
    }

    public void Run()
    {
        if (CheckCollider() && DirX != 0f)
        {
            transform.position += new Vector3(DirX * _speed * Time.deltaTime, 0, 0);
            _animator.SetInteger("IntState", 1);

            if (DirX > 0 && !_rotate)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                _rotate = true;
                Direchion = 1;
            }
            else if (DirX < 0 && _rotate)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                _rotate = false;
                Direchion = -1;
            }
        }
        else
        {
            _animator.SetInteger("IntState", 0);
            DirX = 0;
        }

    }

    public bool ChackGround()
    {
        float _groundCheck = 0.2f;
        return Physics2D.OverlapCircle(_checkGroundPosihon.position, _groundCheck, _groundMask);
    }

    public void Jump()
    {
        if (_playerHealf.Block && ChackGround())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _forgeJamp);
            _animator.SetTrigger("Jump");
        }
    }
    
    private bool CheckCollider()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, new Vector2(DirX,0), 0.5f, _wallLayer);
        if (hit2D.collider != null)
            return false;

        return true;
    }
}
