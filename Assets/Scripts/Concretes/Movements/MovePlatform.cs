using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : IMove
{
    private PlatformMove _platform;
    private float _moveSpeed;

    public MovePlatform(PlatformMove platform, float moveSpeed)
    {
        _moveSpeed = moveSpeed;
        _platform = platform;
    }

    public void Move(float direction)
    {
        _platform.transform.position = (new Vector2(_platform.transform.position.x + Mathf.PingPong(Time.time, 4), 0) * Time.deltaTime *_moveSpeed * direction);
    }
}