using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayController : MonoBehaviour
{
    public void SetAnimation(bool isAnimationActive)
    {
        GetComponent<Animator>().SetBool("hayJump", isAnimationActive);
    }
}