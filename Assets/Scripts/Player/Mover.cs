using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _horizontalSpeed;

    private Rigidbody _rigidbody;
    private float _moveHorizontal;
    private Vector3 _movement;

    
    public event UnityAction<float> Running;
    public event UnityAction Jumping;
    public event UnityAction<float> HorizontalMove;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void MovementLogic(float value)
    {
        _moveHorizontal = value;
        _movement = new Vector3(_moveHorizontal*_horizontalSpeed, 0, 1 * _speed);
        
        HorizontalMove?.Invoke(_moveHorizontal);
        _rigidbody.MovePosition(transform.position + _movement * Time.fixedDeltaTime);
        Running?.Invoke(2);
    }
    
    public void JumpLogic()
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            Jumping?.Invoke();
        }
    }
    
    private bool IsGrounded()
    {
        bool isGrounded =
            Physics.CheckBox(transform.position, new Vector3(0.01f, 0.01f, 0.01f));

        return isGrounded;
    }
}
