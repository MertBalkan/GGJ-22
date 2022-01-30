using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationCanvas : MonoBehaviour
{

    [Multiline]
    [SerializeField] private string _infoText;
    [SerializeField] private AudioClip _typeSound;
    private AudioSource _audioSource;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _audioSource = GetComponent<AudioSource>();
    }
    public IEnumerator StartWriting()
    {
        foreach (char i in _infoText)
        {
            _text.text += i;
            _audioSource.Play();
            if (i.ToString().Equals("."))
            {
                _infoText = "A";
                yield return new WaitForSeconds(0.5f);
            }
            else yield return new WaitForSeconds(0.06f);
        }
    }
}
