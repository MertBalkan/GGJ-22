using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassInteraction : MonoBehaviour
{
    [SerializeField] private float _jumpForceFromGrass;
    [SerializeField] private EnergyController _energyController;
    private IInput _input;
    private bool _canEat = false;

    private void Awake()
    {
        _input = new PCInput();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag.Equals("Grass") && other.contacts[0].normal.y > 0.6f || other.contacts[0].normal.y < -0.6f)
        {
            var hayObject = other.gameObject.GetComponent<HayController>();
            if (hayObject != null)
            {
                hayObject.SetAnimation(true);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime * _jumpForceFromGrass);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Grass"))
        {
            other.gameObject.GetComponent<HayController>().SetAnimation(false);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.contacts[0].normal.y > 0.6f || other.contacts[0].normal.y < -0.6f)
            _canEat = false;
        if (other.contacts[0].normal.x > 0.6f || other.contacts[0].normal.x < -0.6f)
            _canEat = true;

        if (other.gameObject.tag.Equals("Grass") && _input.EatGrass && _canEat)
        {
            _energyController.EnergyAmount += this.gameObject.GetComponent<SheepController>().TotalAmount;
            Destroy(other.gameObject);
        }
    }
}
