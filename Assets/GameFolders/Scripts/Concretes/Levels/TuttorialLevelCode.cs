using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuttorialLevelCode : MonoBehaviour
{
    [Header("SILUET")]
    [SerializeField] private GameObject _siluet;

    private bool _amIHuman = true;

    public bool AmIHuman { get => _amIHuman; set => _amIHuman = value; }
}
