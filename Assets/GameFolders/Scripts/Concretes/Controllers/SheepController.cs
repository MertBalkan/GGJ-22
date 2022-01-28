using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MyCharacterController, IEntity
{
    protected override void Awake()
    {
        base.Awake();
        _move = new MovePlayer(this, _moveSpeed, WhichCharacterEnum.Sheep);
        _flip = new FlipMovement(this, WhichCharacterEnum.Sheep);
    }
    protected override void Update()
    {
        base.Update();
        SlowTimePower();
    }
    private void SlowTimePower()
    {

        if (_input.TimeAdjustButton)
        {
            _energyController.EnergyAmount -= TotalAmount;
            GetComponent<TimeController>().MakeTimeToSlow();
        }
    }
}