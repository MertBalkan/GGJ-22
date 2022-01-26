using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignController : MonoBehaviour
{
    [SerializeField] private string _writeText;
    [SerializeField] private GameObject _canvas;
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
    public void SetAnimation(bool isAnimationActive)
    {
        GetComponent<Animator>().SetBool("signAnim", isAnimationActive);
    }
    public void SetCanvas(bool isCanvasActive)
    {
        _canvas.SetActive(isCanvasActive);
    }
}