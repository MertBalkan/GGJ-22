using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float _platformMoveSpeed;
    private IMove _move;

    private void Awake()
    {
        _move = new MovePlatform(this, _platformMoveSpeed);
    }

    private void Update()
    {
        _move.Move(1);
    }
}