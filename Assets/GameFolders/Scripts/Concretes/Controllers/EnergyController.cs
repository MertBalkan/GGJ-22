using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    [SerializeField] private float _energyAmount;

    public float EnergyAmount { get => _energyAmount; set => _energyAmount = value; }
}