using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : IOnGround
{
    private bool _isOnGround;
    public bool IsOnGround { get { return _isOnGround; } set { value = _isOnGround; } }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("a");
            IsOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("B");
            IsOnGround = false;
        }
    }
}
