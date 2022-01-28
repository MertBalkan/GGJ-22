using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : IMove
{
    private IEntity _entity;
    private WhichCharacterEnum _whichCharacter;
    private float _moveSpeed;

    public MovePlayer(IEntity entity, float moveSpeed, WhichCharacterEnum whichCharacter)
    {
        _entity = entity;
        _moveSpeed = moveSpeed;
        _whichCharacter = whichCharacter;
    }
    public void Move(float direction)
    {
        if (_whichCharacter == WhichCharacterEnum.Wolf)
        {
            _entity.transform.Translate(Vector3.left * _moveSpeed * direction * Time.deltaTime);
        }
        else if (_whichCharacter == WhichCharacterEnum.Sheep)
        {
            _entity.transform.Translate(Vector3.right * _moveSpeed * direction * Time.deltaTime);
        }
        else if (_whichCharacter == WhichCharacterEnum.Default)
        {
            _entity.transform.Translate(Vector3.right * _moveSpeed * direction * Time.deltaTime);
        }
    }
}
