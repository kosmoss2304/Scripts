using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private const string DirectionMovement = "Horizontal";
    private const string AnimationTriggerFall = "Fall";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
   
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded = false;

    private void Start()
    {       
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {   
        float x = Input.GetAxis(DirectionMovement);
        
        SetTriggerAnimation(x);
     
        transform.Translate(new Vector3(x, 0, 0) * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;          
        }

        if (_isGrounded == false)
        {
            _animator.SetTrigger(AnimationTriggerFall);
        }
    }

    private void SetTriggerAnimation(float directionMovement)
    {
        if (directionMovement < 0)
        {
            _spriteRenderer.flipX = true;

            if (_isGrounded)
            {
                _animator.SetTrigger("Run");
            }
        }
        else if (directionMovement > 0)
        {
            _spriteRenderer.flipX = false;

            if (_isGrounded)
            {
                _animator.SetTrigger("Run");
            }
        }
        else if (directionMovement == 0)
        {
            if (_isGrounded)
            {
                _animator.SetTrigger("Idle");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TilemapCollider2D tilimapCollisionObject))
        {
            _isGrounded = true;
        }   
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;               
    }
}
