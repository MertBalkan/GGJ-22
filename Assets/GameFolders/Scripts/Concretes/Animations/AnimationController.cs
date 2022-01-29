using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : IAnimation
{
    private IEntity _entity;
    public AnimationController(IEntity entity)
    {
        _entity = entity;
    }

    public void MoveAnimation(float direction)
    {
        direction = Mathf.Abs(direction);
        _entity.transform.GetComponent<Animator>().SetFloat("direction", direction);
    }

    public void DashAnimation()
    {
        throw new System.NotImplementedException();
    }

    public void JumpAnimation()
    {
        throw new System.NotImplementedException();
    }
}