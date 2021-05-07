using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public float _initialLifeSpan;
    private float _bulletLifeSpan;
   
    void Update()
    {
        _bulletLifeSpan -= Time.deltaTime;

        if(_bulletLifeSpan <= 0)
        {
            _bulletLifeSpan = _initialLifeSpan;
            SimplePool.Despawn(this.gameObject);
            

        }
    }
}
