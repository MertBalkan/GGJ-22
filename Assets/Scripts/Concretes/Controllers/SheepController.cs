using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MyCharacterController, IEntity
{
    private bool _isEatGrass;
    private void OnTriggerEnter2D(Collider2D other)
    {
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Grass") && _input.EatGrass)
        {
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Grass") && _input.EatGrass)
        {
            Debug.Log("AFIED");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("Grass") && !_input.EatGrass)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.fixedDeltaTime * 5000);
        }
    }

}