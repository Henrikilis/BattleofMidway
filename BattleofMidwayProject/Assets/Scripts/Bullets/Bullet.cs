using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Vector2 _velocity;
    public float _speed;
    public float _rotation;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rotation);
    }

    // Bullet Movement
    void LateUpdate()
    {     
        transform.Translate(_velocity * _speed * Time.deltaTime);
    }
}
