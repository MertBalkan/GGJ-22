using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MyCharacterController, IEntity
{

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<TimeController>().MakeTimeToSlow();
        }
    }

}