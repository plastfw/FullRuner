using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _mover.Jumping += OnJumping;
        _mover.Running += OnRunning;
    }

    private void OnDisable()
    {
        _mover.Jumping -= OnJumping;
        _mover.Running -= OnRunning;
    }

    private void OnRunning(float speed)
    {
        _animator.SetFloat("Speed",speed);
    }

    private void OnJumping()
    {
        _animator.SetTrigger("Jump");
    }
}
