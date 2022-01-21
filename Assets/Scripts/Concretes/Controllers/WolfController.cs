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

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_input.Dash)
        {
            Debug.Log("DASH HAPPENED!");
            _dash.DashMovement();
        }
    }

    protected override void Update() {
        base.Update();
    }
}