using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : IDash
{
    private WolfController _wolfController;
    private IInput _input;
    private float _dashSpeed;

    public Dash(WolfController wolfController, IInput input, float dashSpeed)
    {
        _input = input;
        _dashSpeed = dashSpeed;
        _wolfController = wolfController;
    }

    public void DashMovement()
    {
        if (_input.HorizontalMove < 0)
        {
            // _wolfController.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Time.fixedDeltaTime * _dashSpeed);
            _wolfController.GetComponent<Rigidbody2D>().velocity = Vector2.right * Time.fixedDeltaTime * _dashSpeed;
        }
        else if (_input.HorizontalMove > 0)
        {
            // _wolfController.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Time.fixedDeltaTime * _dashSpeed);
            _wolfController.GetComponent<Rigidbody2D>().velocity = Vector2.left * Time.fixedDeltaTime * _dashSpeed;
        }
    }
}