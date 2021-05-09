using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    private Bullet _b;

    public GameObject[] _muzzles;
    public GameObject _bullet;

    private float _fireInterval;
    private float _fireRate;

    public float _maxRandom;

    [Header("Bullet Propreties")]
    public float bulletSpeed;
    public Vector2 bulletVelocity;

    void Start()
    {
        _b = _bullet.GetComponent<Bullet>();
        _fireInterval = Random.Range(0, 10);   
        SimplePool.Preload(_bullet, 5);     
    }

    
    void FixedUpdate()
    {
        _b._velocity = bulletVelocity;
        _b._speed = bulletSpeed;

        if (_fireRate < _fireInterval)
            _fireRate += Time.deltaTime;
        else if (_fireRate >= _fireInterval)
        {
            _fireRate = 0;
            EnemyShot();
        }
    }

    void EnemyShot()
    {
        _fireInterval = Random.Range(0, _maxRandom);
        foreach (GameObject obj in _muzzles)
        {       
            GameObject bullet = SimplePool.Spawn(_bullet, obj.gameObject.transform.position, Quaternion.identity);          
        }

    }

}
