using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Mover _playerMover;
    private float _jumpValue;
    private float _horizontalValue;

    private void Start()
    {
        _playerMover = GetComponent<Mover>();
    }

    private void Update()
    {
        InputHorizontalMovement();
    }

    private void FixedUpdate()
    {
        InputJump();
    }

    public void InputJump()
    {
        _jumpValue = Input.GetAxis("Jump");

        if (_jumpValue > 0)
        {
            _playerMover.Jump();
        }
    }

    public void InputHorizontalMovement()
    {
        _horizontalValue = Input.GetAxis("Horizontal");

        _playerMover.MovementLogic(_horizontalValue);
    }
}
