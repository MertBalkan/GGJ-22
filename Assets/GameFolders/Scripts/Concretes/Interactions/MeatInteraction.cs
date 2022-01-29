using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatInteraction : MonoBehaviour
{
    [SerializeField] private EnergyController _energyController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Meat"))
        {
            _energyController.EnergyAmount += this.gameObject.GetComponent<WolfController>().TotalAmount;
            Destroy(other.gameObject);
        }
    }
}
