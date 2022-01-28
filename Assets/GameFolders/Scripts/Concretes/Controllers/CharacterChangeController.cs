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

    [Header("WHICH CHARACTER")]
    [Space(20)]
    [SerializeField] private WhichCharacterEnum _currentCharacter;

    [SerializeField] private Cinemachine.CinemachineVirtualCamera _virtualCamera;

    private IInput _input;

    private void Awake()
    {
        _input = new PCInput();
    }
    private void Start()
    {
        _currentCharacter = WhichCharacterEnum.Sheep;
    }
    private void Update()
    {
        ChangeCharacter();
        CheckTransform();
    }
    private void ChangeCharacter()
    {
        if (_input.ChangeCharacterButton && _sheepCharacter.activeInHierarchy)
        {
            _virtualCamera.m_Lens.Dutch = 180;
            _currentCharacter = WhichCharacterEnum.Wolf;
            ControlChangeStates(_wolfCharacter, _sheepCharacter, false, true);
            SetImageActivity();
        }
        else if (_input.ChangeCharacterButton && !_sheepCharacter.activeInHierarchy)
        {
            _virtualCamera.m_Lens.Dutch = 0;
            _currentCharacter = WhichCharacterEnum.Sheep;
            ControlChangeStates(_sheepCharacter, _wolfCharacter, true, false);
            SetImageActivity();
        }
    }
    private void CheckTransform()
    {
        if (!_sheepCharacter.activeInHierarchy)
            transform.position = _wolfCharacter.transform.position;
        else
            transform.position = _sheepCharacter.transform.position;
    }
    private void ControlChangeStates(GameObject toObj, GameObject thisObj, bool sheepSituation, bool wolfSituation)
    {
        _sheepCharacter.SetActive(sheepSituation);
        toObj.transform.position = thisObj.transform.position;
        _wolfCharacter.SetActive(wolfSituation);
    }
    private void SetImageActivity()
    {
        if (_currentCharacter == WhichCharacterEnum.Sheep)
        {
            _sheepImage.SetActive(true);
            _wolfImage.SetActive(false);
        }
        else if (_currentCharacter == WhichCharacterEnum.Wolf)
        {
            _sheepImage.SetActive(false);
            _wolfImage.SetActive(true);
        }
        else
        {
            _sheepImage.SetActive(false);
            _wolfImage.SetActive(false);
        }
    }
}