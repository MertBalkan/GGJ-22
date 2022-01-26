using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : IOnGround
{
    private bool _isOnGround;
    public bool IsOnGround { get { return _isOnGround; } set { value = _isOnGround; } }

}
