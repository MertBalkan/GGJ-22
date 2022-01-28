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
        _dash = new Dash(this, _input, _dashSpeed);
    }

    protected override void Update()
    {
        base.Update();

        if (_health.IsDead) return;

        if (_input.Dash)
        {
            _energyController.EnergyAmount -= TotalAmount;
            _dash.DashMovement();
        }
    }
}