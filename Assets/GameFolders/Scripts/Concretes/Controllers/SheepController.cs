using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MyCharacterController, IEntity
{
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