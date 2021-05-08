using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Ship Propreties")]
    public Vector2 _shipVelocity;
    public float _shipSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(_shipVelocity * _shipSpeed * Time.deltaTime);
    }
}
