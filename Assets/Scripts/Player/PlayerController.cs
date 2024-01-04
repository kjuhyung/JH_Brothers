using System;
using UnityEngine;

public class PlayerController : JHCharacterController
{
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection = Vector2.zero;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();        
    }

    private void Start()
    {
        OnMoveEvent += PlayerMove;
        OnFireEvent += PlayerFire;
        OnJumpEvent += PlayerJump;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void PlayerMove(Vector2 direction)
    {
        _movementDirection = direction;
    }
    
    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _movementSpeed;

        _rigidbody.velocity = direction;
    }

    private void PlayerFire()
    {

    }

    private void PlayerJump()
    {

    }
}
