using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour
{
    [SerializeField] private EnergyController _energyController;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    private void Update()
    {
        _slider.value = _energyController.EnergyAmount;
    }

}