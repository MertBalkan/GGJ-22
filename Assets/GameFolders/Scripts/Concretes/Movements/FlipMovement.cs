using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMovement : IFlip
{
    private IEntity _entity;
    private WhichCharacterEnum _whichCharacterEnum;

    public FlipMovement(IEntity entity, WhichCharacterEnum whichCharacterEnum)
    {
        _entity = entity;
        _whichCharacterEnum = whichCharacterEnum;
    }
    public void Flip(float direction, float scaleValue)
    {
        if (direction == 0) return;
        direction = Mathf.Sign(direction);

        if (_whichCharacterEnum == WhichCharacterEnum.Sheep)
        {
            Vector2 flipVector = new Vector2(direction * _entity.transform.localScale.x, _entity.transform.localScale.y);

            Vector2 newFlipVector = direction > 0 ? flipVector = new Vector2(direction - scaleValue, _entity.transform.localScale.y) : flipVector = new Vector2(direction + scaleValue, _entity.transform.localScale.y);

            _entity.transform.localScale = newFlipVector;
        }
        else if (_whichCharacterEnum == WhichCharacterEnum.Wolf)
        {
            Vector2 flipVector = new Vector2(direction * _entity.transform.localScale.x, _entity.transform.localScale.y);

            Vector2 newFlipVector = direction > 0 ? flipVector = new Vector2(direction - scaleValue, _entity.transform.localScale.y) : flipVector = new Vector2(direction + scaleValue, _entity.transform.localScale.y);

            _entity.transform.localScale = newFlipVector;
        }
        else
        {
            Vector2 flipVector = new Vector2(direction * _entity.transform.localScale.x, _entity.transform.localScale.y);

            Vector2 newFlipVector = direction > 0 ? flipVector = new Vector2(direction, _entity.transform.localScale.y) : flipVector = new Vector2(direction, _entity.transform.localScale.y);

            _entity.transform.localScale = newFlipVector;
        }
    }
}