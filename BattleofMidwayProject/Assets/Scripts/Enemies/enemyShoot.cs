using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public GameObject[] _muzzles;
    public GameObject _bullet;

    private float _fireInterval;
    private float _fireRate;

    public float _maxRandom;

    [Header("Bullet Propreties")]
    public float _bulletSpeed;
    public Vector2 _bulletVelocity;

    void Start()
    {
        _fireInterval = Random.Range(0, 10);   
        SimplePool.Preload(_bullet, 5);
    }

    
    void FixedUpdate()
    {
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
            _bullet.GetComponent<Bullet>().SetMoveDirection(_bulletVelocity, _bulletSpeed);
        }

    }

}
