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
    private void Start()
    {
        StartCoroutine(StartWriting());
    }
    private IEnumerator StartWriting()
    {
        foreach (char i in _infoText)
        {
            _text.text += i;
            _audioSource.pitch = Random.Range(1f, 1.2f);
            _audioSource.PlayOneShot(_typeSound);
            if (i.ToString().Equals(".")) yield return new WaitForSeconds(1.0f);
            else yield return new WaitForSeconds(0.2f);
        }
    }
}
