using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [Header("Boss Movement")]
    public Vector2 _shipVelocity;
    public float _shipSpeed;

    public Transform _posA;
    public Transform _posB;
    void Start()
    {
        _posA.gameObject.transform.parent = null;
        _posB.gameObject.transform.parent = null;
    }

    void FixedUpdate()
    {
        transform.Translate(_shipVelocity * _shipSpeed * Time.deltaTime);

        if(transform.position.x > _posB.position.x)
        {
            _shipVelocity = new Vector2(-1, 0);
        }
        if (transform.position.x < _posA.position.x)
        {
            _shipVelocity = new Vector2(1, 0);
        }
    }
}
