using UnityEngine;

namespace PlayerControllers
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Transform _groundCheckPoint;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private SawChecker _sawChecker;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private AudioSource _firstJumpSound;
        [SerializeField] private AudioSource _doubleJumpSound;

        private Joystick _joystick;
        private bool _isDoubleJump;
        private bool _isJumped;
        private bool _isGround;
        private Rigidbody2D _rigidbody;
        private float _directionX;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
            _animator = GetComponent<Animator>();
            _animator.SetBool($"{GameDataLoader.GetNameCharacter()}", true);
        }

        private void Update()
        {
            CheckMovement();
            CheckMovement();
            CheckDirection();
            CheckJump(); 
            CheckGround();
        }   

        private void FixedUpdate()
        {
            DoMovement();
        }

        private void CheckMovement()
        {
            _directionX = _joystick.Horizontal * _speed;
        }

        private void DoMovement()
        {
            _rigidbody.velocity = new Vector2(-_directionX, _rigidbody.velocity.y);
        }

        private void CheckDirection()
        {
            if (_joystick.Horizontal > 0) ChangeDirection(true);
            else if (_joystick.Horizontal < 0) ChangeDirection(false);
        }

        private void CheckJump()
        {
            if (_joystick.Vertical <= -0.87f) Jump(); 
            else if (!_isDoubleJump && _isJumped) _isDoubleJump = true;
        }

        private void CheckGround()
        {
            _isGround = Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _whatIsGround);
            if (_isGround) _sawChecker.CheckJumpedSaws();
        }

        private void Jump()
        {
            if (_isGround)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
                _isJumped = true;
                _firstJumpSound.Play();
            }
            else if (_isDoubleJump && _isJumped)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
                _isDoubleJump = false;
                _isJumped = false;
                _doubleJumpSound.Play();
            }
        }

        private void ChangeDirection(bool isRight)
        {
            _spriteRenderer.flipX = isRight;
        }
    }
}

