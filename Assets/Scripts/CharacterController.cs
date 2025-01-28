using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterController : MonoBehaviour
{
    private const string STOP_MOVE_ANIM_TRIGGER = "Stop";
    private const string MOVE_UP_ANIM_TRIGGER = "Up";
    private const string MOVE_DOWN_ANIM_TRIGGER = "Down";
    private const string MOVE_LEFT_ANIM_TRIGGER = "Left";
    private const string MOVE_RIGHT_ANIM_TRIGGER = "Right";

    private enum MoveDirections
    {
        Up,
        Down,
        Left,
        Right,
    }

    [SerializeField] private float _speed = 4f;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rb;
    private Vector2 _direction;
    private MoveDirections _currentMoveInputDirection;
    private List<MoveDirections> _moveInputDirections = new List<MoveDirections>();

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveInputKeyUpHandler();

        MoveInputKeyDownHandler();
        
        MoveHandler();

        _direction.Normalize();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _direction * _speed;
    }

    private void MoveInputKeyUpHandler()
    {
        if(Input.GetKeyUp("w"))
        {
            _moveInputDirections.Remove(MoveDirections.Up);
            UpdateMoveInput();
        }

        if(Input.GetKeyUp("s"))
        {
            _moveInputDirections.Remove(MoveDirections.Down);
            UpdateMoveInput();
        }

        if(Input.GetKeyUp("a"))
        {
            _moveInputDirections.Remove(MoveDirections.Left);
            UpdateMoveInput();
        }

        if(Input.GetKeyUp("d"))
        {
            _moveInputDirections.Remove(MoveDirections.Right);
            UpdateMoveInput();
        }
    }

    private void MoveInputKeyDownHandler()
    {
        if(Input.GetKeyDown("w"))
        {
            AddMoveInput(MoveDirections.Up, MOVE_UP_ANIM_TRIGGER);
        }

        if(Input.GetKeyDown("s"))
        {
            AddMoveInput(MoveDirections.Down, MOVE_DOWN_ANIM_TRIGGER);
        }

        if(Input.GetKeyDown("a"))
        {
            AddMoveInput(MoveDirections.Left, MOVE_LEFT_ANIM_TRIGGER);
        }

        if(Input.GetKeyDown("d"))
        {
            AddMoveInput(MoveDirections.Right, MOVE_RIGHT_ANIM_TRIGGER);
        }
    }

    private void MoveHandler()
    {
        if(Input.GetKey("w") && _currentMoveInputDirection == MoveDirections.Up)
        {
            UpdateMoveVector(Vector2.up, MOVE_UP_ANIM_TRIGGER);
        }

        if(Input.GetKey("s") && _currentMoveInputDirection == MoveDirections.Down)
        {
            UpdateMoveVector(Vector2.down, MOVE_DOWN_ANIM_TRIGGER);
        }

        if(Input.GetKey("a") && _currentMoveInputDirection == MoveDirections.Left)
        {
            UpdateMoveVector(Vector2.left, MOVE_LEFT_ANIM_TRIGGER);
        }

        if(Input.GetKey("d") && _currentMoveInputDirection == MoveDirections.Right)
        {
            UpdateMoveVector(Vector2.right, MOVE_RIGHT_ANIM_TRIGGER);
        }
    }

    private void UpdateMoveInput()
    {
        if(_moveInputDirections.Count() > 0)
        {
            _currentMoveInputDirection = _moveInputDirections.Last();
        }
        else
        {
            _direction = new Vector2(0, 0);

            if(!StateNameController.IsGamePaused)
            {
                _animator.SetTrigger(STOP_MOVE_ANIM_TRIGGER);
            }
        }
    }   

    private void AddMoveInput(MoveDirections direction, string animTrigger)
    {
        _currentMoveInputDirection = direction;

        _moveInputDirections.Add(direction);
        if(!StateNameController.IsGamePaused)
        {
            _animator.SetTrigger(animTrigger);
        }
    }

    private void UpdateMoveVector(Vector2 moveVector, string animTrigger)
    {
        if(_direction != moveVector && !StateNameController.IsGamePaused)
        {
            _animator.SetTrigger(animTrigger);
        }
        _direction = moveVector;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        _animator.SetTrigger(STOP_MOVE_ANIM_TRIGGER);
        _moveInputDirections.Clear();
    }
}