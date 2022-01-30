using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private InformationCanvas _infoCanvas;

    private void Start()
    {
        _infoCanvas.StartCoroutine(_infoCanvas.StartWriting());
    }
}
