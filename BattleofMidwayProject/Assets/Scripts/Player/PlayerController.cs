using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Ship Speed")]
    [SerializeField]
    private float _moveSpeed;
    private PlayerInputActions _playerInput;
    private Rigidbody2D _rb;

    public bool _canMove;
    
    void Awake()
    {
        _canMove = true;
        _playerInput = new PlayerInputActions();
        _rb = GetComponent<Rigidbody2D>();
    }
    // Disable and Enable
    private void OnEnable()
    {
        _playerInput.Enable();    
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    // Topdown Movement System
    void FixedUpdate()
    {
        if (_canMove)
        {
            Vector2 _moveInput = _playerInput.Movement.Move.ReadValue<Vector2>();
            _rb.velocity = _moveInput * _moveSpeed;
        }
    }
}
