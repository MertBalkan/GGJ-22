using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class MyCharacterController : MonoBehaviour, IEntity
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _currentHealth;
    protected IMove _move;
    protected IInput _input;
    protected IJump _jump;
    protected IHealth _health;

    private Rigidbody2D _rb;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = new PCInput();
        _move = new MovePlayer(this, _moveSpeed);
        _jump = new JumpPlayer(_rb, _jumpForce);
        _health = new Health(_currentHealth);
    }

    protected virtual void FixedUpdate()
    {
        if (_input.CharacterJump)
        {
            _jump.Jump();
        }
    }
    protected virtual void Update()
    {
        if (_health.IsDead) //if character is dead then return and dont do anything. This will suddenly stop player's move
        {
            GameManager.Instance.LoadNextSceneWithID(1); //loading next scene here... maybe we can change this one's position later
            return;
        }

        if (_input.HorizontalMove != 0)
            _move.Move(_input.HorizontalMove);

        if (_input.CharacterJump && _jump.OnGround)
            _jump.Jump();

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckOnGround(other, true);

        if (other.gameObject.tag.Equals("Obstacle"))
        {
            _health.TakeDamage(_currentHealth); //this kills player suddenly
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        CheckOnGround(other, false);
    }

    private void CheckOnGround(Collision2D other, bool onGroundSituation)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            _jump.OnGround = onGroundSituation;
        }
    }
}