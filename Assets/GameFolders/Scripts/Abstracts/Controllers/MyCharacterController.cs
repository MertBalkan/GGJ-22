using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class MyCharacterController : MonoBehaviour, IEntity
{
    [SerializeField] private float _scaleValue;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _totalAmount;

    [SerializeField] protected EnergyController energyController;
    [SerializeField] private InformationCanvas _infoCanvas;

    protected IMove _move;
    protected IInput _input;
    protected IJump _jump;
    protected IHealth _health;
    protected IFlip _flip;
    protected IAnimation _animation;
    private Rigidbody2D _rb;
    public static SignController currentSign;

    public float TotalAmount { get => _totalAmount; set => _totalAmount = value; }
    public EnergyController EnergyController { get => energyController; set => energyController = value; }

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = new PCInput();
        _jump = new JumpPlayer(_rb, _jumpForce);
        _health = new Health(_currentHealth);
        _animation = new AnimationController(this);

    }

    protected virtual void FixedUpdate()
    {

    }
    protected virtual void Update()
    {
        if (_health.IsDead) //if character is dead then return and dont do anything. This will suddenly stop player's move
        {
            GameManager.Instance.LoadNextSceneWithID(2); //loading next scene here... maybe we can change this one's position later
            return;
        }

        if (_input.HorizontalMove != 0)
        {
            _flip.Flip(_input.HorizontalMove, _scaleValue);
            _move.Move(_input.HorizontalMove);
            _animation.MoveAnimation(_input.HorizontalMove);
        }

        if (_input.CharacterJump && _jump.OnGround)
        {
            _jump.Jump();
            _animation.JumpAnimation(true);
        }
        if (_jump.OnGround)
        {
            _animation.JumpAnimation(false);
        }

    }
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        CheckOnGround(other, true);

        if (other.gameObject.tag.Equals("Obstacle"))
        {
            _health.TakeDamage(_currentHealth); //this kills player suddenly
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D other)
    {
        CheckOnGround(other, false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Sign"))
        {
            var signObject = other.gameObject.GetComponent<SignController>();
            currentSign = signObject;
            if (signObject != null)
            {
                _infoCanvas.StartCoroutine(_infoCanvas.StartWriting());
                signObject.SetCanvas(true);
                signObject.SetAnimation(true);
            }
        }
        if (other.gameObject.tag.Equals("EndLevel"))
        {
            GameManager.Instance.LoadNextSceneWithID(3);
        }
        if (other.gameObject.tag.Equals("From"))
        {
            this.transform.position = GameObject.FindGameObjectWithTag("To").gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var signObject = other.gameObject.GetComponent<SignController>();

        if (signObject != null)
        {
            signObject.SetCanvas(false);
            signObject.SetAnimation(false);
        }
    }

    private void CheckOnGround(Collision2D other, bool onGroundSituation)
    {
        if (other.gameObject.tag.Equals("Ground"))
            _jump.OnGround = onGroundSituation;
    }
}