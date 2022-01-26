using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : IJump
{
    private Rigidbody2D _rb;
    private float _jumpForce;
    private bool _onGround;
    public bool OnGround { get => _onGround; set => _onGround = value; }

    public JumpPlayer(Rigidbody2D rb, float jumpForce)
    {
        _rb = rb;
        _jumpForce = jumpForce;
    }

    public void Jump()
    {
        if (_onGround)
        {
            _rb.AddForce(Vector2.up * _jumpForce * Time.fixedDeltaTime);
            _onGround = false;
        }
    }
}