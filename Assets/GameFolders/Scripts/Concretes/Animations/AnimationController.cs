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
        _entity.transform.GetComponent<Animator>().SetTrigger("dash");
    }

    public void JumpAnimation(bool isJump)
    {
        _entity.transform.GetComponent<Animator>().SetBool("isJump", isJump);
    }

    public void EatGrass()
    {
        _entity.transform.GetComponent<Animator>().SetTrigger("eatGrass");
    }
}