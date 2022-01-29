using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour, IEntity
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _scaleValue;
    private IInput _input;
    private IMove _move;
    private IFlip _flip;
    private IAnimation _anim;
    private bool _canChangeCharacter;

    public bool CanChangeCharacter { get => _canChangeCharacter; set => _canChangeCharacter = value; }

    private void Awake()
    {
        _input = new PCInput();
        _move = new MovePlayer(this, _moveSpeed, WhichCharacterEnum.Default);
        _flip = new FlipMovement(this, WhichCharacterEnum.Default);
        _anim = new AnimationController(this);
    }

    private void Update()
    {
        if (_input.HorizontalMove != 0)
        {
            _anim.MoveAnimation(_input.HorizontalMove);
            _flip.Flip(_input.HorizontalMove, _scaleValue);
            _move.Move(_input.HorizontalMove);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag.Equals("Siluet"))
        {
            GameManager.Instance.LoadNextSceneWithID(1);
            Destroy(other.gameObject);
        }
    }
}