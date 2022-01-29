using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour, IEntity
{
    [SerializeField] private float _moveSpeed;
    private IInput _input;
    private IMove _move;
    private IFlip _flip;
    private bool _canChangeCharacter;

    public bool CanChangeCharacter { get => _canChangeCharacter; set => _canChangeCharacter = value; }

    private void Awake()
    {
        _input = new PCInput();
        _move = new MovePlayer(this, _moveSpeed, WhichCharacterEnum.Default);
        _flip = new FlipMovement(this, WhichCharacterEnum.Default);
    }

    private void Update()
    {
        if (_input.HorizontalMove != 0)
        {
            _flip.Flip(_input.HorizontalMove);
            _move.Move(_input.HorizontalMove);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag.Equals("Siluet"))
        {
            CanChangeCharacter = true;
        }
    }
}