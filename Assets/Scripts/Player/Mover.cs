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

    private Rigidbody _rigidbody;
    private float _moveHorizontal;
    private Vector3 _movement;
    private int _linePosition;
    private float _stepSize = 1.5f;

    public event UnityAction<float> Running;
    public event UnityAction Jumping;
    public event UnityAction<float> HorizontalMove;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _linePosition = 2;
    }

    private void Update()
    {
        Debug.Log(IsGrounded());
        MovementLogic();
    }
    
    private void FixedUpdate()
    {
        JumpLogic();
    }
    
    private void MovementLogic()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _movement = new Vector3(0, 0, 1);
        
        HorizontalMove?.Invoke(_moveHorizontal);
        Running?.Invoke(2);
        
        MoveHorizontal();
        transform.Translate(_movement * _speed);
    }

    private void MoveHorizontal()
    {
        if (Input.GetKeyDown(KeyCode.D) && _linePosition != 3) 
        {
            SetLine(_stepSize);
            _linePosition++;
        }

        if (Input.GetKeyDown(KeyCode.A) && _linePosition != 1) 
        {
            SetLine(-_stepSize);
            _linePosition--;
        }
    }

    private void SetLine(float value)
    {
        transform.position += new Vector3(value, 0, 0);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0 && IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce,ForceMode.Impulse);
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
