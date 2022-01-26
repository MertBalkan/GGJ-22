using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SignController : MonoBehaviour
{
    [SerializeField] private string _writeText;
    
    private TextMeshProUGUI _text;
    
    public string WriteText { get => _writeText; set => _writeText = value; }

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start() {
        _text.text = _writeText;
    }
}