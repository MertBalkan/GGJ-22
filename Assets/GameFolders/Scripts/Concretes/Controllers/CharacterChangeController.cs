using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterChangeController : MonoBehaviour
{
    [Header("CHARACTERS")]
    [SerializeField] private GameObject _wolfCharacter;
    [SerializeField] private GameObject _sheepCharacter;
    [SerializeField] private GameObject _humanCharacter; //only in tut
    [SerializeField] private GameObject _midSheep; //added
    [SerializeField] private GameObject _midWolf;

    [Header("IMAGES")]
    [Space(20)]
    [SerializeField] private GameObject _wolfImage;
    [SerializeField] private GameObject _sheepImage;

    [Header("SLIDERS")]
    [Space(20)]
    [SerializeField] private Slider _wolfSlider;
    [SerializeField] private Slider _sheepSlider;

    [Header("WHICH CHARACTER")]
    [Space(20)]
    [SerializeField] private WhichCharacterEnum _currentCharacter;

    [SerializeField] private Cinemachine.CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private HumanController _human;

    private TuttorialLevelCode _tuttorial;
    private IInput _input;

    public WhichCharacterEnum CurrentCharacter { get => _currentCharacter; set => _currentCharacter = value; }

    private void Awake()
    {
        _input = new PCInput();
    }
    private void Start()
    {
        CurrentCharacter = WhichCharacterEnum.Default;
        _tuttorial = FindObjectOfType<TuttorialLevelCode>();
    }
    private void Update()
    {
        ChangeCharacter();
        CheckVirtualCameraRotation();
        SetSliderActivity();
    }

    private void LateUpdate()
    {
        CheckTransform();
    }
    private void ChangeCharacter()
    {
        if (_input.ChangeCharacterButton && _sheepCharacter.activeInHierarchy && _human.CanChangeCharacter)
        {
            _tuttorial.AmIHuman = false;
            CurrentCharacter = WhichCharacterEnum.Wolf;

            ControlChangeStates(_wolfCharacter, _sheepCharacter, false, true);
            SetImageActivity();
        }
        else if (_input.ChangeCharacterButton && !_sheepCharacter.activeInHierarchy && _human.CanChangeCharacter)
        {
            _tuttorial.AmIHuman = false;
            CurrentCharacter = WhichCharacterEnum.Sheep;
            ControlChangeStates(_sheepCharacter, _wolfCharacter, true, false);
            SetImageActivity();
        }
        else if(_tuttorial.AmIHuman){
            CurrentCharacter = WhichCharacterEnum.Default;
            SetImageActivity();
        }
    }
    private void CheckVirtualCameraRotation()
    {
        if (CurrentCharacter == WhichCharacterEnum.Sheep)
        {
            _human.gameObject.SetActive(false);
            _virtualCamera.m_Lens.Dutch = Mathf.Lerp(_virtualCamera.m_Lens.Dutch, 0, 3f * Time.deltaTime);
            _midSheep.SetActive(true);
            _midWolf.SetActive(false);
        }
        else if (CurrentCharacter == WhichCharacterEnum.Wolf)
        {
            _virtualCamera.m_Lens.Dutch = Mathf.Lerp(_virtualCamera.m_Lens.Dutch, 180, 3f * Time.deltaTime);
            _midSheep.SetActive(false);
            _midWolf.SetActive(true);
        }
    }
    private void CheckTransform()
    {
        if (_wolfCharacter.activeInHierarchy)
            transform.position = _wolfCharacter.transform.position;
        else if(_sheepCharacter.activeInHierarchy)
            transform.position = _sheepCharacter.transform.position;
        else if(_humanCharacter.activeInHierarchy)
            transform.position = _humanCharacter.transform.position;
    }
    private void ControlChangeStates(GameObject toObj, GameObject thisObj, bool sheepSituation, bool wolfSituation)
    {
        _sheepCharacter.SetActive(sheepSituation);
        toObj.transform.position = thisObj.transform.position;
        _wolfCharacter.SetActive(wolfSituation);
    }
    private void SetImageActivity()
    {
        if (CurrentCharacter == WhichCharacterEnum.Sheep)
        {
            _sheepImage.SetActive(true);
            _wolfImage.SetActive(false);
        }
        else if (CurrentCharacter == WhichCharacterEnum.Wolf)
        {
            _sheepImage.SetActive(false);
            _wolfImage.SetActive(true);
        }
        else if(CurrentCharacter == WhichCharacterEnum.Default)
        {
            _sheepImage.SetActive(false);
            _wolfImage.SetActive(false);
        }
    }
    private void SetSliderActivity(){
        if (CurrentCharacter == WhichCharacterEnum.Sheep)
        {
            _sheepSlider.gameObject.SetActive(true);
            _wolfSlider.gameObject.SetActive(false);
        }
        else if (CurrentCharacter == WhichCharacterEnum.Wolf)
        {
            _sheepSlider.gameObject.SetActive(false);
            _wolfSlider.gameObject.SetActive(true);
        }
        else
        {
            _sheepSlider.gameObject.SetActive(false);
            _wolfSlider.gameObject.SetActive(false);
        }
    }
}