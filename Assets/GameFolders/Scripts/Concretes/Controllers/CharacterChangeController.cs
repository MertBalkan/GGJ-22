using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangeController : MonoBehaviour
{
    [Header("CHARACTERS")]
    [SerializeField] private GameObject _wolfCharacter;
    [SerializeField] private GameObject _sheepCharacter;

    [Header("IMAGES")]
    [Space(20)]
    [SerializeField] private GameObject _wolfImage;
    [SerializeField] private GameObject _sheepImage;

    private IInput _input;

    private void Awake()
    {
        _input = new PCInput();
    }
    private void Update()
    {
        ChangeCharacter();
    }
    private void ChangeCharacter()
    {
        if (_input.ChangeCharacterButton && _sheepCharacter.activeInHierarchy)
        {
            ControlChangeStates(_wolfCharacter, _sheepCharacter, false, true);
        }
        else if (_input.ChangeCharacterButton && !_sheepCharacter.activeInHierarchy)
        {
            ControlChangeStates(_sheepCharacter, _wolfCharacter, true, false);
        }
    }
    private void ControlChangeStates(GameObject toObj, GameObject thisObj, bool sheepSituation, bool wolfSituation)
    {
        _sheepCharacter.SetActive(sheepSituation);
        toObj.transform.position = thisObj.transform.position;
        _wolfCharacter.SetActive(wolfSituation);
    }
}