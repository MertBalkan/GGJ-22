using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignController : MonoBehaviour
{
    [Multiline]
    [SerializeField] private string _writeText;
    [SerializeField] private GameObject _signCanvas;
    [SerializeField] private TextMeshProUGUI _text;

    public string WriteText { get => _writeText; set => _writeText = value; }

    private void Update()
    {
        _text.text = _writeText;
    }
    public void SetAnimation(bool isAnimationActive)
    {
        GetComponent<Animator>().SetBool("signAnim", isAnimationActive);
    }
    public void SetCanvas(bool isCanvasActive)
    {
        _signCanvas.SetActive(isCanvasActive);
    }
}