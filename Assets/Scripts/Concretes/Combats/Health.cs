using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    
    private float _currentHealth;
    public bool IsDead => _currentHealth <= 0;
    public float CurrentHealth => _currentHealth;

    public Health(float currentHealth)
    {
        _currentHealth = currentHealth;
    }

    public void TakeDamage(float damageCount)
    {
        if(IsDead) return;

        if(!IsDead) 
            _currentHealth -= damageCount;
    }
}