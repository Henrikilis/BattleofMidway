﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Vector2 _velocity;
    public float _speed;
    private BoxCollider2D _bc;
    public float _rotation;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rotation);
        _bc = GetComponent<BoxCollider2D>();
    }

    // Bullet Movement
    void LateUpdate()
    {     
        transform.Translate(_velocity * _speed * Time.deltaTime);
    }
    
}
