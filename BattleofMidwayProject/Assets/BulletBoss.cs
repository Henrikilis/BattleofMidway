using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    private Vector2 _vel;
    [SerializeField]
    private float _speed;

    void Start()
    {
        _speed = 5f;
    }

   
    void FixedUpdate()
    {
        transform.Translate(_vel * _speed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 _dir)
    {

        _vel = _dir;

    }

}
