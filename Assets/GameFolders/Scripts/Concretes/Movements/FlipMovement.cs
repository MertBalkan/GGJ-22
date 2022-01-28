using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMovement : IFlip
{
    private IEntity _entity;

    public FlipMovement(IEntity entity)
    {
        _entity = entity;
    }
    public void Flip(float direction)
    {
        if(direction == 0) return;
        direction = Mathf.Sign(direction);

        Vector2 flipVector = new Vector2(direction * _entity.transform.localScale.x, _entity.transform.localScale.y);

        Vector2 newFlipVector = direction > 0 ? flipVector = new Vector2(direction, _entity.transform.localScale.y) : flipVector = new Vector2(direction, _entity.transform.localScale.y);

        _entity.transform.localScale = newFlipVector;
    }
}