using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangeController : MonoBehaviour
{
    [SerializeField] private GameObject _wolfCharacter;
    [SerializeField] private GameObject _sheepCharacter;

    private IInput _input;

    private void Awake()
    {
        _input = new PCInput();
    }
    private void Update()
    {
        if (_input.ChangeCharacterButton && _sheepCharacter.activeInHierarchy)
        {
            _sheepCharacter.SetActive(false);
            _wolfCharacter.transform.position = _sheepCharacter.transform.position;
            _wolfCharacter.SetActive(true);
        }
        else if (_input.ChangeCharacterButton && !_sheepCharacter.activeInHierarchy)
        {
            _sheepCharacter.SetActive(true);
            _sheepCharacter.transform.position = _wolfCharacter.transform.position;
            _wolfCharacter.SetActive(false);
        }
    }
}