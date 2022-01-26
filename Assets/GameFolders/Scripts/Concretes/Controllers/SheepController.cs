using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MyCharacterController, IEntity
{
    protected override void Update()
    {
        base.Update();
        if (_input.TimeAdjustButton)
        {
            GetComponent<TimeController>().MakeTimeToSlow();
        }
    }
}