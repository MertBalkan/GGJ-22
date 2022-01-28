using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MyCharacterController
{
    [SerializeField] private float _dashSpeed;
    private IDash _dash;

    protected override void Awake()
    {
        base.Awake();
        _move = new MovePlayer(this, _moveSpeed, WhichCharacterEnum.Wolf);
        _dash = new Dash(this, _input, _dashSpeed);
        _flip = new FlipMovement(this, WhichCharacterEnum.Wolf);
    }

    protected override void Update()
    {
        base.Update();

        if (_health.IsDead) return;

        if (_input.Dash)
        {
            energyController.EnergyAmount -= TotalAmount;
            _dash.DashMovement();
        }
    }
}