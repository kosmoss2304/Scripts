using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Transform _transform;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded = false;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x < 0)
        {
            _spriteRenderer.flipX = true;

            if (_isGrounded)
            {
                _animator.SetTrigger("Run");
            }
        }
        else if (x > 0)
        {
            _spriteRenderer.flipX = false;

            if (_isGrounded)
            {
                _animator.SetTrigger("Run");
            }
        }
        else if (x == 0)
        {
            if (_isGrounded)
            {
                _animator.SetTrigger("Idle");
            }
        }

        Vector3 movement = new Vector3(x, 0, 0);
        _transform.Translate(movement * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;          
        }

        if (_isGrounded == false)
        {
            _animator.SetTrigger("Fall");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D tilimapCollisionObject))
        {
            _isGrounded = true;
        }   
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;               
    }
}
