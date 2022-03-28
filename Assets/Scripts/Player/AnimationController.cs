using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _mover.Jumping += OnJumping;
        _mover.Running += OnRunning;
        _mover.HorizontalMove += OnHorizontalMoving;
    }

    private void OnDisable()
    {
        _mover.Jumping -= OnJumping;
        _mover.Running -= OnRunning;
        _mover.HorizontalMove -= OnHorizontalMoving;
    }

    private void OnRunning(float speed)
    {
        _animator.SetFloat("Speed",speed);
    }

    private void OnJumping()
    {
        _animator.SetTrigger("Jump");
    }

    private void OnHorizontalMoving(float value)
    {
        _animator.SetFloat("HorizontalMove",value);
    }
}
