using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public float _initialLifeSpan;
    private float _bulletLifeSpan;

    private void Awake()
    {
        _bulletLifeSpan = _initialLifeSpan;
    }

    void FixedUpdate()
    {
        _bulletLifeSpan -= Time.deltaTime;

        if(_bulletLifeSpan <= 0)
        {
            _bulletLifeSpan = _initialLifeSpan;
            SimplePool.Despawn(this.gameObject);
            

        }
    }
}
