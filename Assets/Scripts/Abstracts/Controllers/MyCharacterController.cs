using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class MyCharacterController : MonoBehaviour, IEntity
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    protected IMove _move;
    protected IInput _input;
    protected IJump _jump;

    private Rigidbody2D _rb;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = new PCInput();
        _move = new MovePlayer(this, _moveSpeed);
        _jump = new JumpPlayer(_rb, _jumpForce);
    }

    protected virtual void FixedUpdate()
    {
        if (_input.CharacterJump){
            _jump.Jump();
        }
    }
    protected virtual void Update()
    {
        if (_input.HorizontalMove != 0)
            _move.Move(_input.HorizontalMove);

        if (_input.CharacterJump && _jump.OnGround)
            _jump.Jump();

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            _jump.OnGround = true;
            Debug.Log(_jump.OnGround);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            _jump.OnGround = false;
            Debug.Log(_jump.OnGround);
        }
    }
}