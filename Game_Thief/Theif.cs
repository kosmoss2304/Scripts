using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Theif : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isGrounded;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        const string DirectionMovement = "Horizontal";

        float x = Input.GetAxis(DirectionMovement);

        transform.Translate(new Vector3(x, 0, 0) * Time.deltaTime * _speed);

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {           
            _rigidbody2D.AddForce(Vector3.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }
}
