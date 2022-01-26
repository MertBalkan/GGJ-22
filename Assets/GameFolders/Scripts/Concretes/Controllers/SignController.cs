using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignController : MonoBehaviour
{
    [SerializeField] private string _writeText;
    
    private TextMeshProUGUI _text;

    public string WriteText { get => _writeText; set => _writeText = value; }

    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (_text != null)
            _text.text = _writeText;
    }
    public void PlayAnimation()
    {
        GetComponent<Animator>().SetBool("signAnim", true);
    }
    public void StopAnimation()
    {
        GetComponent<Animator>().SetBool("signAnim", false);
    }
    public void ActiveCanvas()
    {

    }
    public void DeactiveCanvas()
    {

    }
}