using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _playerHeight;
    [SerializeField] private float _radius;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    private Transform _transform;
    
    public event UnityAction<float> Running;
    public event UnityAction Jumping;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }
    
    private void Update()
    {
        // Debug.Log(IsGrounded());
        
        NormalizedSpeed();
        Running?.Invoke(0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            Run();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void Run()
    {
        Running?.Invoke(2);
        
        // _rigidbody.AddForce(Vector3.forward * _speed, ForceMode.Acceleration);
        _transform.position = _transform.position + new Vector3(0, 0, 0.1f);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            Jumping?.Invoke();
            // _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Acceleration);
            _transform.position = _transform.position + new Vector3(0, 1, 0);
        }
    }

    private void MoveLeft()
    {
        _transform.position = _transform.position - new Vector3(1, 0, 0);
        // _rigidbody.AddForce(Vector3.left * _speed, ForceMode.Acceleration);
    }
    
    private void MoveRight()
    {
        _transform.position = _transform.position + new Vector3(1, 0, 0);
        // _rigidbody.AddForce(Vector3.right * _speed, ForceMode.Acceleration);
    }

    private void NormalizedSpeed()
    {
        if (_rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = Physics.CheckCapsule(new Vector3(transform.position.x,transform.position.y+_playerHeight,transform.position.z),transform.position,_radius);

        return isGrounded;
    }
}
