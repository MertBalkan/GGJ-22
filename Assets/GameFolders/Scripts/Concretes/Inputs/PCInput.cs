using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput : IInput
{
    public bool CharacterJump => Input.GetKeyDown(KeyCode.Space);
    public bool Dash => Input.GetKeyDown(KeyCode.E);
    public bool EatGrass => Input.GetKey(KeyCode.E);
    public bool TimeAdjustButton => Input.GetKeyDown(KeyCode.T);
    public bool ChangeCharacterButton => Input.GetKeyDown(KeyCode.Q);
    public float VerticalMove => Input.GetAxis("Vertical");
    public float HorizontalMove => Input.GetAxis("Horizontal");
}
