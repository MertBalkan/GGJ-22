using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : IMove
{
    private IEntity _entity;
    private float _moveSpeed;

    public MovePlayer(IEntity entity, float moveSpeed)
    {
        _entity = entity;
        _moveSpeed = moveSpeed;
    }
    public void Move(float direction)
    {
        _entity.transform.Translate(Vector3.right * _moveSpeed * direction * Time.deltaTime);
    }
}
